using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Unit;
using TestTools.Structure;

namespace TestTools
{
    public class TestFactory
    {
        public StructureService StructureService { get; set; } 

        public UnitTestConfiguration DefaultConfiguration { get; set; } = new UnitTestConfiguration();

        public TestFactory(string fromNamespace, string toNamespace)
        {
            StructureService = new StructureService(fromNamespace, toNamespace);
        }

        public UnitTest CreateTest()
        {
            throw new NotImplementedException();
        }

        public StructureTest CreateStructureTest()
        {
            return new StructureTest(StructureService);
        }
    }
}
