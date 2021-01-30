using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

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
            test.AssertConstructor<string, TextFile>(s => new TextFile(s), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 7B
        [TestMethod("TestFile.Content is public read-only string"), TestCategory("7B")]
        public void TestFileContentIsPublicReadOnlyString()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<TextFile, string>(t => t.Content, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("TestFile.Content reads file content correctly"), TestCategory("7B")]
        public void TestFileContentReadsFileContentCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> file = test.CreateVariable<TextFile>();
            TestFileSystem fileSystem = test.CaptureFileSystem();

            fileSystem.Act(fs => fs.File.Create("/file.txt"));
            fileSystem.Act(fs => fs.File.WriteAllText("/file.txt", "content of file"));
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

        [TestMethod("TextFile.Content equals null after TextFile.Dispose()"), TestCategory("7C")]
        public void TextFileContentEqualsNullAfterDisposable()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> file = test.CreateVariable<TextFile>();
            TestFileSystem fileSystem = test.CaptureFileSystem();

            fileSystem.Act(fs => fs.File.Create("/file.txt"));
            fileSystem.Act(fs => fs.File.WriteAllText("/file.txt", "content of file"));
            test.Arrange(file, Expr(() => new TextFile("/file.txt")));
            test.Act(Expr(file, f => f.Dispose()));
            test.Assert.IsNotNull(Expr(file, f => f.Content == null));

            test.Execute();
        }
        #endregion
    }
}
