using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
    public class Exercise_7_Tests 
    {
        #region Exercise 7A
        [TestMethod("TextFile constructor takes string"), TestCategory("7A")]
        public void TextFileConstructorTakesString()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, TextFile>(s => new TextFile(s));
            test.Execute();
        }
        #endregion

        #region Exercise 7B
        [TestMethod("TestFile.Content is public read-only string"), TestCategory("7B")]
        public void TestFileContentIsPublicReadOnlyString()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<TextFile, string>(t => t.Content);
            test.Execute();
        }

        private void TestSetup()
        {
            IFileSystem fs = new FileSystem();
            fs.File.WriteAllText("./file.txt", "content of file");
        }

        [TestMethod("TestFile.Content reads file content correctly"), TestCategory("7B")]
        public void TestFileContentReadsFileContentCorrectly()
        {
            TestSetup();

            TextFile file = new TextFile("./file.txt");
            Assert.AreEqual(file.Content, "content of file");
            file.Dispose();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> _file = test.CreateVariable<TextFile>();
            TestSetup();
            test.Arrange(_file, Expr(() => new TextFile("./file.txt")));
            test.Assert.IsTrue(Expr(_file, f => f.Content == "content of file"));
            test.Act(Expr(_file, f => f.Dispose()));
            test.Execute();
        }
        #endregion

        #region Exercise 7C
        [TestMethod("TextFile implements IDisposable"), TestCategory("7C")]
        public void TextFileImplementsIDisposable()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<TextFile>(new TypeIsSubclassOfVerifier(typeof(IDisposable)));
            test.Execute();
        }

        [TestMethod("TextFile.Content equals null after TextFile.Dispose()"), TestCategory("7C")]
        public void TextFileContentEqualsNullAfterDisposable()
        {
            TestSetup();

            TextFile file = new TextFile("./file.txt");

            file.Dispose();

            Assert.IsNull(file.Content);

            // TestTool Code
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> _file = test.CreateVariable<TextFile>();
            test.Arrange(_file, Expr(() => new TextFile("./file.txt")));
            test.Act(Expr(_file, f => f.Dispose()));
            test.Assert.IsNull(Expr(_file, f => f.Content));
            test.Execute();
        }
        #endregion
    }
}
