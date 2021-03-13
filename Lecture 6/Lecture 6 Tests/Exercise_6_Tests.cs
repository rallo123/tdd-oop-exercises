using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;
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
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertInterface<ILogger>();
            test.Execute();
        }

        [TestMethod("b.ILogger.Log(string message) is a method"), TestCategory("6A")]
        public void ILoggerLogIsAMehthod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ILogger, string>((l, s) => l.Log(s));
            test.Execute();
        }
        #endregion

        #region Exercise 6B
        [TestMethod("a. FileLogger's constructor takes string"), TestCategory("6B")]
        public void DieConstructorTakesIRandomAndInt()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, ILogger>(s => new FileLogger(s));
            test.Execute();
        }
        #endregion

        #region Exercise 6C
        [TestMethod("a. FileLogger implements ILogger"), TestCategory("6C")]
        public void FileLoggerImplementILogger()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<FileLogger>(
                new TypeAccessLevelVerifier(AccessLevels.Public),
                new TypeIsSubclassOfVerifier(typeof(ILogger)));
            test.Execute();
        }
        #endregion

        #region Exercise 6D
        [TestMethod("a. FileLogger implements IDisposable"), TestCategory("6D")]
        public void FileLoggerImplementIDisposable()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<FileLogger>(
                new TypeAccessLevelVerifier(AccessLevels.Public),
                new TypeIsSubclassOfVerifier(typeof(IDisposable)));
            test.Execute();
        }
        #endregion

        #region Exercise 6E
        private void FileLoggerAppendsFileSetup()
        {
            string path = "./log.txt";
            
            if (File.Exists(path))
                File.Delete(path);
            File.WriteAllText(path, "Customer Ryan Johnson was created" + Environment.NewLine);
        }

        [TestMethod("b. FileLogger.Log(string message) appends file"), TestCategory("6E")]
        public void FileLoggerAppendsFile()
        {
            // FAILS AT THE MOMENT AND MORE WORK IS NEEDED ON THIS
            FileLoggerAppendsFileSetup();
            
            FileLogger logger = new FileLogger("./log.txt");
            
            logger.Log("Customer Ryan Johnson was deleted");
            logger.Dispose();

            string expectedContent = string.Join(
                Environment.NewLine, 
                "Customer Ryan Johnson was created", 
                "Customer Ryan Johnson was deleted");
            Assert.AreEqual(File.ReadAllText("./log.txt"), expectedContent);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<FileLogger> _logger = test.CreateVariable<FileLogger>();
            FileLoggerAppendsFileSetup();
            test.Arrange(_logger, Expr(() => new FileLogger("./log.txt")));
            test.Act(Expr(_logger, l => l.Log("Customer Ryan Johnson was deleted")));
            test.Act(Expr(_logger, l => l.Dispose()));
            test.Assert.AreEqual(
                Expr(() => File.ReadAllText("./log.txt")), 
                Const(expectedContent));
            test.Execute();
        }
        #endregion
    }
}
