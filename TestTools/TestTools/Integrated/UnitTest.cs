using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    public class UnitTest
    {
        public UnitTestConfiguration Configuration { get; set; } = new UnitTestConfiguration();

        internal UnitTest()
        {

        }

        public void Assert<T>(UnitTestObject<T> obj, Expression<Func<T, T, bool>> assertion)
        {
            throw new NotImplementedException();
        }

        public UnitTestConsole CreateConsole()
        {
            throw new NotImplementedException();
        }

        public UnitTestFileSystem CreateFileSystem()
        {
            throw new NotImplementedException();
        }

        public UnitTestClass CreateClass()
        {
            throw new NotImplementedException();
        }

        public UnitTestObject<T> CreateObject<T>()
        {
            return CreateObject<T>(typeof(T).Name.ToLower());
        }

        public UnitTestObject<T> CreateObject<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public AnonymousUnitTestObject<T> CreateAnonymousObject<T>()
        {
            return CreateAnonymousObject<T>(typeof(T).Name.ToLower());
        }

        public AnonymousUnitTestObject<T> CreateAnonymousObject<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public DualUnitTestObject<T> CreateDualObject<T>()
        {
            return CreateDualObject<T>(typeof(T).Name.ToLower());
        }

        public DualUnitTestObject<T> CreateDualObject<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public AnonymousUnitDualTestObject<T> CreateDualAnonymousObject<T>()
        {
            return CreateDualAnonymousObject<T>(typeof(T).Name.ToLower());
        }

        public AnonymousUnitDualTestObject<T> CreateDualAnonymousObject<T>(string nickname)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {

        }
    }
}
