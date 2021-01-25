using Lecture_8_Solutions;
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
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4B
        [TestMethod("a. ConsoleController.HandleInput(string input) is a public method"), TestCategory("4B")]
        public void ConsoleViewRunIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ConsoleController, string>((c, s) => c.HandleInput(s), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. ConsoleController.HandleInput(\"Echo Hello world\") echos"), TestCategory("4B")]
        public void ConsoleControllerHandleInputEchos()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput("Echo Hello world"));
            console.Assert.HasWrittenLine("Hello world");

            test.Execute();
        }

        [TestMethod("c. ConsoleController.HandleInput(\"Reverse Hello world\") reverses"), TestCategory("4B")]
        public void ConsoleControllerHandleInputReverses()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput("Reverse Hello world"));
            console.Assert.HasWrittenLine("dlroW olleH");

            test.Execute();
        }

        [TestMethod("d. ConsoleController.HandleInput(\"Greet world\") greets"), TestCategory("4B")]
        public void ConsoleControllerHandleInputGreets()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput("Greet World"));
            console.Assert.HasWrittenLine("Hello World");

            test.Execute();
        }

        [TestMethod("e. ConsoleController.HandleInput(\"NonExistentCommand Hello World\") errors"), TestCategory("4B")]
        public void ConsoleControllerHandleInputErrors()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput("NonExistentCommand Hello World"));
            console.Assert.HasWrittenLine("Command NonExistentCommand not found");

            test.Execute();
        }

        [TestMethod("f. ConsoleController.HandleInput(\"Greet\") errors"), TestCategory("4B")]
        public void ConsoleControllerHandleInputErrors2()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput("Greet"));
            console.Assert.HasWrittenLine("Please provide a command argument");

            test.Execute();
        }

        [TestMethod("g. ConsoleController.HandleInput(\"\") errors"), TestCategory("4B")]
        public void ConsoleControllerHandleInputErrors3()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestConsole console = test.CreateConsole();

            controller.Arrange(() => new ConsoleController());
            controller.Act(c => c.HandleInput(""));
            console.Assert.HasWrittenLine("Please provide a command");

            test.Execute();
        }
        #endregion

        #region exercise 4C
        [TestMethod("a. ConsoleController.AddCommand(string name, Action<string> action) is a public method"), TestCategory("4C")]
        public void ConsoleControllerAddCommand()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ConsoleController, string, Action<string>>((c, s, a) => c.AddCommand(s, a), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. ConsoleController.AddCommand(\"SayGoodbye\", (s) => ...) adds command"), TestCategory("4C")]
        public void ConsoleConstrollerAddCommandAddsCommand()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestObject<Action<string>> action = test.CreateObject<Action<string>>();
            UnitTestConsole console = test.CreateConsole();


            controller.Arrange(() => new ConsoleController());
            action.Arrange(LambdaAction<string>((s) => Console.WriteLine(s)));
            controller.WithParameters(action).Act((c, a) => c.AddCommand("SayGoodbye", a));
            controller.Act(c => c.HandleInput("SayGoodbye World"));
            console.Assert.HasWrittenLine("Goodbye World");

            test.Execute();
        }
        #endregion

        #region Exercise 4D
        public void ConsoleControllerRemoveCommand()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ConsoleController, string>((c, s) => c.RemoveCommand(s), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. ConsoleController.RemoveCommand(\"SayGoodbye\") removes command again"), TestCategory("4D")]
        public void ConsoleControllerRemoveCommandRemovesCommand()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<ConsoleController> controller = test.CreateObject<ConsoleController>();
            UnitTestObject<Action<string>> action = test.CreateObject<Action<string>>();
            UnitTestConsole console = test.CreateConsole();


            controller.Arrange(() => new ConsoleController());
            action.Arrange(LambdaAction<string>((s) => Console.WriteLine(s)));
            controller.WithParameters(action).Act((c, a) => c.AddCommand("SayGoodbye", a));
            controller.WithParameters(action).Act((c, a) => c.RemoveCommand("SayGoodbye"));
            controller.Act(c => c.HandleInput("SayGoodbye World"));
            console.Assert.HasWrittenLine("Command SayGoodbye not found");

            test.Execute();
        }
        #endregion
    }
}
