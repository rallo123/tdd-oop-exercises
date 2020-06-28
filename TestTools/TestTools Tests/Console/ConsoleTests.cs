using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.ConsoleSession;

namespace TestTools_Tests
{
    [TestClass]
    public class ConsoleTests
    {
        private void Echo()
        {
            string str = Console.ReadLine();
            Console.WriteLine(str);
        }

        [TestMethod]
        public void ProducesExpectedOutputWithOut()
        {
            ConsoleSession session = new ConsoleSession();
            session.Out("Hello world!");
            session.Start(() => Console.WriteLine("Hello world!"));
        }

        [TestMethod]
        public void ProducesExpectedOutputWithIn()
        {
            ConsoleSession session = new ConsoleSession();
            session.In("Hello world!\n");
            session.Start(() => Console.ReadLine());
        }

        [TestMethod]
        public void ProducesExpectedOutputWithInAndOut()
        {
            ConsoleSession session = new ConsoleSession();
            session.In("Hello world!\n");
            session.Out("Hello world!");
            session.Start(Echo);
        }

        [TestMethod]
        public void ProducesExpectedOutputWithRepeatedIn()
        {
            ConsoleSession session = new ConsoleSession();
            session.In("Hello world!\n");
            session.Out("Hello world!\n");
            session.In("Hello world!\n");
            session.Out("Hello world!\n");
            session.Start(() => { Echo(); Echo(); });
        }
    }
}
