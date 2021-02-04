using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;
using System.Linq;
using System.IO.Abstractions;

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
        public void FileLoggerAppendsFileSetup()
        {
            IFileSystem fs = new FileSystem();
            fs.File.Create("/log.txt");
            fs.File.WriteAllText("/log.txt", "Customer Ryan Johnson was created");
        }

        [TestMethod("b. FileLogger.Log(string message) appends file"), TestCategory("6E")]
        public void FileLoggerAppendsFile()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<FileLogger> file = test.CreateVariable<FileLogger>();
            TestVariable<IFileSystem> fileSystem = test.CaptureFileSystem();

            FileLoggerAppendsFileSetup();
            test.Arrange(file, Expr(() => new FileLogger("/log.txt")));
            test.Act(Expr(file, l => l.Log("Customer Ryan Johnson was deleted")));
            test.Act(Expr(file, l => l.Dispose()));
            test.Assert.AreEqual(
                Expr(fileSystem, fs => fs.File.ReadAllText("/log.text")), 
                Const("Customer Ryan Johnson was Created\n Customer Ryan Johnson was deleted"));

            test.Execute();
        }
        #endregion
    }
}
