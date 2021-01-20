using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_3_Tests 
    {
        #region Exercise 3A
        [TestMethod("TextFile constructor takes string"), TestCategory("3A")]
        public void TextFileConstructorTakesString()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<string, TextFile>(s => new TextFile(s), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("TestFile.Content is public read-only string"), TestCategory("3B")]
        public void TestFileContentIsPublicReadOnlyString()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<TextFile, string>(t => t.Content, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("TestFile.Content reads file content correctly"), TestCategory("3B")]
        public void TestFileContentReadsFileContentCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<TextFile> file = test.CreateObject<TextFile>();
            UnitTestFileSystem fileSystem = test.CreateFileSystem();

            fileSystem.Act(fs => fs.File.Create("/file.txt"));
            fileSystem.Act(fs => fs.File.WriteAllText("/file.txt", "content of file"));
            file.Arrange(() => new TextFile("/file.txt"));
            file.Assert.IsTrue(f => f.Content == "content of file");

            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("TextFile implements IDisposable"), TestCategory("3C")]
        public void TextFileImplementsIDisposable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<TextFile>(t => t.GetInterface("IDisposable") != null);
            test.Execute();
        }

        [TestMethod("TextFile.Content equals null after TextFile.Dispose()"), TestCategory("3C")]
        public void TextFileContentEqualsNullAfterDisposable()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<TextFile> file = test.CreateObject<TextFile>();
            UnitTestFileSystem fileSystem = test.CreateFileSystem();

            fileSystem.Act(fs => fs.File.Create("/file.txt"));
            fileSystem.Act(fs => fs.File.WriteAllText("/file.txt", "content of file"));
            file.Arrange(() => new TextFile("/file.txt"));
            file.Act(f => f.Dispose());
            file.Assert.IsTrue(f => f.Content == null);

            test.Execute();
        }
        #endregion
    }
}
