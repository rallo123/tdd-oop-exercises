using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture_6_Solutions
{
    public class TextFile : IDisposable
    {
        bool _isDisposed = false;
        StreamReader _reader;

        public TextFile(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _reader = new StreamReader(stream, Encoding.UTF8);
        }

        public string Content
        {
            get
            {
                if (!_isDisposed)
                {
                    return _reader.ReadToEnd();
                }
                return null;
            }
        }

        public void Dispose()
        {
            _reader.Dispose();
            _isDisposed = true;
        }
    }
}
