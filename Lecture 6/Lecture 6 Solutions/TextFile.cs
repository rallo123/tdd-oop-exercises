using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture_6_Solutions
{
    public class TextFile : IDisposable
    {
        FileStream stream;

        public TextFile(string path)
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public string Content
        {
            get
            {
                using var sr = new StreamReader(stream, Encoding.UTF8);
                return sr.ReadToEnd();
            }
        }

        public void Dispose()
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }
    }
}
