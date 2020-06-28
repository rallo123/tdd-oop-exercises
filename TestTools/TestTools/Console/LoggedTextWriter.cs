using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestTools.ConsoleSession
{
    internal class LoggedTextWriter : TextWriter
    {
        StringBuilder logger;

        public LoggedTextWriter(StringBuilder logger)
        {
            this.logger = logger;
        }

        public override Encoding Encoding => Encoding.Default;

        public override void Write(char c)
        {
            logger.Append(c);
        }
    }
}
