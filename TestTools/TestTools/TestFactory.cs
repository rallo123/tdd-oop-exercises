using System;
using System.Collections.Generic;
using System.Text;
using TestTools.UnitTests;
using TestTools.StructureTests;

namespace TestTools
{
    public class TestFactory
    {
        public UnitTestConfiguration DefaultConfiguration { get; set; } = new UnitTestConfiguration();

        public TestFactory(string namespaceToProjectOn)
        {
            throw new NotImplementedException();
        }

        public UnitTest CreateTest()
        {
            throw new NotImplementedException();
        }

        public StructureTest CreateStructureTest()
        {
            throw new NotImplementedException();
        }
    }
}
