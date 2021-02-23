using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
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
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, TextFile>(s => new TextFile(s));
            test.Execute();
        }
        #endregion

        #region Exercise 7B
        [TestMethod("TestFile.Content is public read-only string"), TestCategory("7B")]
        public void TestFileContentIsPublicReadOnlyString()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<TextFile, string>(t => t.Content);
            test.Execute();
        }

        public void TestFileContentReadsFileContentCorrectlySetup()
        {
            IFileSystem fs = new FileSystem();
            fs.File.Create("/file.txt");
            fs.File.WriteAllText("/file.txt", "content of file");
        }

        [TestMethod("TestFile.Content reads file content correctly"), TestCategory("7B")]
        public void TestFileContentReadsFileContentCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> file = test.CreateVariable<TextFile>();

            TestFileContentReadsFileContentCorrectlySetup();
            test.Arrange(file, Expr(() => new TextFile("/file.txt")));
            test.Assert.IsTrue(Expr(file, f => f.Content == "content of file"));

            test.Execute();
        }
        #endregion

        #region Exercise 7C
        [TestMethod("TextFile implements IDisposable"), TestCategory("7C")]
        public void TextFileImplementsIDisposable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<TextFile>(t => t.GetInterface("IDisposable") != null);
            test.Execute();
        }

        public void TextFileContentEqualsNullAfterDisposableSetup()
        {
            IFileSystem fs = new FileSystem();
            fs.File.Create("/file.txt");
            fs.File.WriteAllText("/file.txt", "content of file");
        }

        [TestMethod("TextFile.Content equals null after TextFile.Dispose()"), TestCategory("7C")]
        public void TextFileContentEqualsNullAfterDisposable()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> file = test.CreateVariable<TextFile>();

            TextFileContentEqualsNullAfterDisposableSetup();
            test.Arrange(file, Expr(() => new TextFile("/file.txt")));
            test.Act(Expr(file, f => f.Dispose()));
            test.Assert.IsNotNull(Expr(file, f => f.Content == null));

            test.Execute();
        }
        #endregion
    }
}
