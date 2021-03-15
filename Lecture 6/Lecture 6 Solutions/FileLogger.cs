﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture_6_Solutions
{
    public class FileLogger : ILogger, IDisposable
    {
        FileStream stream;

        public FileLogger(string path)
        {
            stream = new FileStream(path, FileMode.Append, FileAccess.Write);
        }

        public void Log(string message)
        {
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.Write(message);
            streamWriter.Flush();
        }

        public void Dispose()
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }
    }
}