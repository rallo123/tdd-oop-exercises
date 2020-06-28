using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestTools.ConsoleSession
{
    internal class LoggedTextReader : TextReader
    {
        int contentIndex = 0;
        string content;
        StringBuilder logger;

        public LoggedTextReader(string content, StringBuilder logger)
        {
            this.content = content;
            this.logger = logger;
        }

        public override int Read()
        {
            char c = content[contentIndex++];
            logger.Append(c);
            return c;
        }

        public override int Peek()
        {
            return content[contentIndex];
        }
    }
}
