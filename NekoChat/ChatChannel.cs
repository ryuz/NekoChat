using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Security;
using System.Threading;

namespace NekoChat
{
    class ChatChannel : IDisposable
    {
        private string channelPath = "";
        public string ChannelPath { get { return channelPath; } }

        private string channelName = "";
        public string ChannelName { set {channelName = value;} get { return channelName; } }

        private string nickName = "";
        public string NickName { get{return nickName;} }
        
        private string key = "";
        public string Key { get{return key;} }

        private string logPath = "";
        public string LogPath { get{return logPath;} }
        private string logFileName;

        private string userFile = "";

        public bool Changed { get; set; }
        public bool Authenticated
        {
            get
            {
                if (chatFile == null)
                {
                    return false;
                }
                return chatFile.Authenticated;
            }
        }

        public bool UnviewedMessage { get; set; }   // 未読メッセージあり
        public bool UnviewedKeyword { get; set; }   // 未読キーワードあり
        

        private FileSystemWatcher fswatcher;

        private object   syncObject = new object();
        private Thread   pollingThread;
        private volatile bool     stopThread;

        private ChatFile chatFile = null;
        
        // コンストラクタ
        public ChatChannel(string channelName, string nickName, string channelPath, string key, string logPath)
        {
            this.channelName = channelName;
            this.channelPath = channelPath;
            this.nickName = nickName;
            this.key      = key;
            this.userList = new ArrayList();
            this.logPath  = logPath;
            
            this.Changed         = false;
            this.UnviewedMessage = false;
            this.UnviewedKeyword = false;
            

            // 変更監視登録
            this.fswatcher = new FileSystemWatcher();
            this.fswatcher.Path   = channelPath;
            this.fswatcher.Filter = "*.txt";
            this.fswatcher.NotifyFilter =
                    (System.IO.NotifyFilters.LastAccess
                    | System.IO.NotifyFilters.LastWrite);
            this.fswatcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
            this.fswatcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
            this.fswatcher.Deleted += new System.IO.FileSystemEventHandler(watcher_Changed);
            this.fswatcher.EnableRaisingEvents = true;

            // userファイル名作成
            String s = CryptString.MakeMd5String(this.channelPath + nickName);

            // ファイル名を作る
            this.userFile = Path.Combine(this.ChannelPath, s + ".user");
            
            // スレッド開始
            this.stopThread = false;
            this.pollingThread = new Thread(new ThreadStart(pollongMain));
            this.pollingThread.Start();
        }
        
        // デストラクタ
        ~ChatChannel()
        {
            Dispose();
        }
        
        
        public void Dispose()
        {
            // スレッド停止
            if (this.pollingThread != null)
            {
                this.stopThread = true;
                this.pollingThread.Join();
                this.pollingThread = null;
            }

            // ユーザーファイル削除
            try
            {
                if (userFile.Length > 0 && System.IO.File.Exists(userFile))
                {
                    System.IO.File.Delete(userFile);
                }
            }
            catch (IOException)
            {
            }
        }

        // ヒストリ
        private ArrayList histry = new ArrayList();
        public void AddHistry(string text)
        {
            histry.Add(text);
        }

        public string GetHistry(int index)
        {
            if (index < 0 || index >= histry.Count)
            {
                return "";
            }
            return (string)histry[histry.Count - index - 1];
        }

        public int GetHistryCount()
        {
            return histry.Count;
        }


        // 送信文字列
        private string writeText = "";
        public void WriteMessage(String text)
        {
            // 送信テキストを予約
            Monitor.Enter(syncObject);
            if (writeText.Length > 0)
            {
                writeText += "\n" + text;
            }
            else
            {
                writeText = text;
            }
            Monitor.Exit(syncObject);
        }

        // 更新文字列取得
        private string updateText = "";
        public String ReadMessage()
        {
            string ut;

            // 受信文字列を返す
            Monitor.Enter(syncObject);
            ut = this.updateText;
            this.updateText = "";
            Monitor.Exit(syncObject);

            return ut;
        }

        // 文字列全体取得
        private string allText = "";
        public string Text
        {
            get
            {
                string tx;

                Monitor.Enter(syncObject);
                tx = this.allText;
                Monitor.Exit(syncObject);

                return tx;
            }
        }

        // ユーザーリスト取得
        private ArrayList userList = new ArrayList();
        public ArrayList UserList
        {
            get
            {
                ArrayList ul;
                Monitor.Enter(syncObject);
                ul = this.userList;
                Monitor.Exit(syncObject);
                
                return ul;
            }
        }
        

        // 変更監視
        private void watcher_Changed(System.Object source,
        System.IO.FileSystemEventArgs e)
        {
            this.Changed = true;
        }

        // チャットファイル設定
        private DateTime setupTodayChatFile()
        {
            // ファイル名を作る
            DateTime dt = DateTime.Now;
            string baseName = dt.ToString("yyyyMMdd") + ".txt";
            string fileName = Path.Combine(this.ChannelPath, baseName);
            this.logFileName = Path.Combine(this.logPath, baseName);
            if (this.chatFile == null || fileName != this.chatFile.FileName)
            {
                this.chatFile = new ChatFile(fileName, this.key);
                this.chatFile.Authenticate(this.nickName);
            }

            return dt;
        }
        
        // 書き込み
        private bool tryWriteMessage(string text)
        {
            setupTodayChatFile();
            return this.chatFile.Write(text);
        }

        // 読み込み
        private String tryReadMessage()
        {
            setupTodayChatFile();
            string str = this.chatFile.Read();
            if (str.Length > 0)
            {
                outputLog(this.chatFile.Text);
            }
            return str;
        }

        // ログ出力
        private void outputLog(string text)
        {
            if (logFileName.Length <= 0) return;

            try
            {
                using (FileStream fs = new FileStream(logFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    sw.Write(text);
                    sw.Close();
                }
            }
            catch (FileNotFoundException)
            {
            }
        }

        private void tryWriteUserFile()
        {
            DateTime dt = DateTime.Now;
            
            if ( !Authenticated )
            {
                return;
            }
            
            try
            {
                using (FileStream fs = new FileStream(userFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    sw.WriteLine(CryptString.EncryptString("neko", this.Key));           // ヘッダ出力
                    sw.WriteLine(CryptString.EncryptString(dt.ToString(), this.Key));    // 時刻出力
                    sw.WriteLine(CryptString.EncryptString(nickName, this.Key));         // ユーザー名
                }
            }
            catch (FileNotFoundException)
            {
            }
        }


        private ArrayList tryReadUserFile()
        {
            ArrayList ul = new ArrayList();

            ul.Clear();

            if ( !Authenticated )
            {
                return ul;
            }

            DirectoryInfo di = new DirectoryInfo(this.channelPath);
            FileInfo[] fi = di.GetFiles("*.user");
            for (int i = 0; i < fi.Length; i++)
            {
                try
                {
                    using (FileStream fs = fi[i].Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        String line;

                        // ヘッダ
                        if ((line = sr.ReadLine()) == null) { continue; }
                        line = CryptString.DecryptString(line, this.Key);
                        if (line != "neko") { continue; }

                        // 時刻
                        if ((line = sr.ReadLine()) == null) { continue; }
                        line = CryptString.DecryptString(line, this.Key);
                        DateTime dt  = DateTime.Parse(line);
                        DateTime now = DateTime.Now;
                        TimeSpan p = now - dt; 
                        double pass = p.TotalSeconds;
                        pass = Math.Abs(pass);
                        if (pass > 180) { continue; }

                        // 名前
                        if ((line = sr.ReadLine()) == null) { continue; }
                        line = CryptString.DecryptString(line, this.Key);
                        ul.Add(line);
                    }
                }
                catch (FileNotFoundException)
                {
                }
            }

            return ul;
        }
        
        
        // スレッド
        private void pollongMain()
        {
            string      wt = "";
            string[]    wt_array = null;
            int         wt_index = 0;
            string      rt;
            int         intervalRx = 0;
            int         intervalUsr = 0;
            bool        updateRx;
            bool        updateUsr;
            bool        first = true;

            for ( ; ; )
            {
                Thread.Sleep(100);


                // 受信更新タイミング決定
                updateRx = false;
                if (intervalRx <= 0 || this.Changed)
                {
                    updateRx = true;
                    this.Changed = false;
                    intervalRx = 300;
                }
                intervalRx--;

                // ユーザーリスト更新タイミング決定
                updateUsr = false;
                if (intervalUsr <= 0)
                {
                    updateUsr = true;
                    intervalUsr = 300;
                }
                intervalUsr--;


                // 送信文字列を取り出す
                if (wt.Length <= 0)
                {
                    Monitor.Enter(syncObject);
                    if (writeText.Length > 0)
                    {
                        wt = writeText;
                        writeText = "";
                    }
                    Monitor.Exit(syncObject);
                    wt_array = wt.Split('\n');
                    wt_index = 0;
                }

                // 送信
                if (wt.Length > 0 && wt_array != null)
                {
                    for ( ; ; )
                    {
                        if (wt_index >= wt_array.Length)
                        {
                            wt_array = null;
                            wt = "";
                            break;
                        }

                        if (!tryWriteMessage(wt_array[wt_index]))
                        {
                            break;
                        }
                        wt_index++;
                    }
                }

                if (updateRx)
                {
                    // 受信処理
                    rt = tryReadMessage();
                    if (rt.Length > 0)
                    {
                        Monitor.Enter(syncObject);
                        if (!first)
                        {
                            this.updateText += rt;
                        }
                        this.allText += rt;
                        Monitor.Exit(syncObject);
                    }
                }

                if (updateUsr)
                {
                    // ユーザーリスト書き込み
                    tryWriteUserFile();
                    updateRx = true;
                }
                
                if (updateRx)
                {
                    // ユーザーリスト読込み
                    ArrayList ul = tryReadUserFile();
                    Monitor.Enter(syncObject);
                    userList = ul;
                    Monitor.Exit(syncObject);
                }

                
                // 停止判定
                if (this.stopThread)
                {
                    return;
                }

                first = false;
            }
        }
    }
}

