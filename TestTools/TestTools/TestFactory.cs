﻿using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Unit;
using TestTools.Structure;

namespace TestTools
{
    public class TestFactory
    {
        public IStructureService StructureService { get; set; } 

        public UnitTestConfiguration DefaultConfiguration { get; set; } = new UnitTestConfiguration();

        public TestFactory(string fromNamespace, string toNamespace)
        {
            StructureService = new StructureService(fromNamespace, toNamespace);
        }

        public UnitTest CreateTest()
        {
            return new UnitTest(StructureService);
        }

        public StructureTest CreateStructureTest()
        {
            return new StructureTest(StructureService);
        }
    }
}
