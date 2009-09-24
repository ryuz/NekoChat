using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NekoChat
{
    class ChatFile
    {
        private StringBuilder textAll = new StringBuilder("");
        public string Text { get { return textAll.ToString(); } }
        private string fileName = "";
        public string FileName { get { return fileName; } }
        private string key = "";
        public string Key { get { return key; } }
        private long currentFilePos = 0;
        private bool authenticated = false;
        public bool Authenticated { get{return authenticated;}}
        
        // コンストラクタ
        public ChatFile(string path, string key)
        {
            this.fileName = path;
            this.key = key;
        }
        
        // 読み込む
        public string Read()
        {
            StringBuilder newText = new StringBuilder();
            
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;

                    // ヘッダ解析
                    if (currentFilePos == 0)
                    {
                        if ((line = sr.ReadLine()) != null)
                        {
                            line = CryptString.DecryptString(line, this.key);
                            if (line.Length < 18 || String.Compare(line, 18, "nekonekocat", 0, 11) != 0)
                            {
                                authenticated = false;
                                return "(key no match)";
                            }
                            authenticated = true;
                        }
                        currentFilePos = fs.Seek(0, SeekOrigin.Current);
                    }

                    fs.Seek(currentFilePos, SeekOrigin.Begin);
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = CryptString.DecryptString(line, this.key);
                        newText.Append(line);
                        newText.Append("\r\n");
                    }

                    // ポインタ更新
                    currentFilePos = fs.Seek(0, SeekOrigin.Current);

                    textAll.Append(newText.ToString());

                    return newText.ToString();
                }
            }
            catch (FileNotFoundException)
            {
                return "";
            }
        }

        // 書き込む
        public bool Write(string text)
        {
            // 認証
            if ( !authenticated )
            {
                return false;
            }

            // メッセージを作成
            string message = CryptString.EncryptString(text, this.Key);

            try
            {
                // 開く
                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(message);
                    sw.Close();
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }


        // 認証実施
        public bool Authenticate(string nickName)
        {
            if (authenticated)
            {
                return true;
            }

            // 開く
            try
            {
                using (FileStream fs = new FileStream(this.fileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // 初回ならヘッダ出力
                    if (fs.Seek(0, SeekOrigin.Current) == 0)
                    {
                        String strHeader;
                        DateTime dt = DateTime.Now;
                        strHeader = dt.ToString("HH:mm:ss ") + String.Format("{0,-8} ", nickName) + "nekonekocat";
                        strHeader = CryptString.EncryptString(strHeader, this.Key);
                        sw.WriteLine(strHeader);
                        authenticated = true;
                    }
                }
            }
            catch (IOException)
            {
            }
            
            return authenticated; 
        }
    }
}
