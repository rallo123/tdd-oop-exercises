﻿using Lecture_6_Solutions;
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
        [TestMethod("a. TextFile constructor takes string"), TestCategory("Exercise 7A")]
        public void TextFileConstructorTakesString()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, TextFile>(s => new TextFile(s));
            test.Execute();
        }
        #endregion

        #region Exercise 7B
        [TestMethod("a. TestFile.Content is public read-only string"), TestCategory("Exercise 7B")]
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

        [TestMethod("b. TestFile.Content reads file content correctly"), TestCategory("Exercise 7B")]
        public void TestFileContentReadsFileContentCorrectly()
        {
            TestSetup();

            TextFile file = new TextFile("./file.txt");
            Assert.AreEqual("content of file", file.Content);
            file.Dispose();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<TextFile> _file = test.CreateVariable<TextFile>();
            TestSetup();
            test.Arrange(_file, Expr(() => new TextFile("./file.txt")));
            test.Assert.AreEqual(Const("content of file"), Expr(_file, f => f.Content));
            test.Act(Expr(_file, f => f.Dispose()));
            test.Execute();
        }
        #endregion

        #region Exercise 7C
        [TestMethod("a. TextFile implements IDisposable"), TestCategory("Exercise 7C")]
        public void TextFileImplementsIDisposable()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<TextFile>(new TypeIsSubclassOfVerifier(typeof(IDisposable)));
            test.Execute();
        }

        [TestMethod("b. TextFile.Content equals null after TextFile.Dispose()"), TestCategory("Exercise 7C")]
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
