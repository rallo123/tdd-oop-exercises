using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.StructureTests;
using TestTools.UnitTests;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;
using System.Linq;

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_6_Tests 
    {
        #region Exercise 6A
        [TestMethod("a.ILogger is an interface"), TestCategory("6A")]
        public void ILoggerIsAnInterface()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertInterface<ILogger>();
            test.Execute();
        }

        [TestMethod("b.ILogger.Log(string message) is a method"), TestCategory("6A")]
        public void ILoggerLogIsAMehthod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ILogger, string>((l, s) => l.Log(s), IsPublicMethod);
            test.Execute();
        }
        #endregion

        #region Exercise 6B
        [TestMethod("a. FileLogger's constructor takes string"), TestCategory("6B")]
        public void DieConstructorTakesIRandomAndInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<string, ILogger>(s => new FileLogger(s), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 6C
        [TestMethod("a. FileLogger implements ILogger"), TestCategory("6C")]
        public void FileLoggerImplementILogger()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<FileLogger>(t => t.GetInterface("ILogger") != null);
            test.Execute();
        }
        #endregion

        #region Exercise 6D
        [TestMethod("a. FileLogger implements IDisposable"), TestCategory("6D")]
        public void FileLoggerImplementIDisposable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<FileLogger>(t => t.GetInterface("IDisposable") != null);
            test.Execute();
        }
        #endregion

        #region Exercise 6E
        [TestMethod("b. FileLogger.Log(string message) appends file"), TestCategory("6E")]
        public void FileLoggerAppendsFile()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<FileLogger> file = test.CreateVariable<FileLogger>();
            TestFileSystem fileSystem = test.CaptureFileSystem();
            
            fileSystem.Act(fs => fs.File.Create("/log.txt"));
            fileSystem.Act(fs => fs.File.WriteAllText("/log.txt", "Customer Ryan Johnson was created"));
            test.Arrange(file, Expr(() => new FileLogger("/log.txt")));
            test.Act(Expr(file, l => l.Log("Customer Ryan Johnson was deleted")));
            test.Act(Expr(file, l => l.Dispose()));
            //fileSystem.Assert.IsTrue(fs.File.ReadAllTest("/log.text") == "Customer Ryan Johnson was Created\n Customer Ryan Johnson was deleted")

            test.Execute();
        }
        #endregion
    }
}
