using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        #region Exercise 3A
        [TestMethod("ConsoleView.Run() is a public method"), TestCategory("3A")]
        public void ConsoleViewRunIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ConsoleView>(v => v.Run(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("BankAccount.Run() returns on empty line input"), TestCategory("3A")]
        public void BankAccount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> view = test.CreateVariable<ConsoleView>();
            TestConsole console = test.CaptureConsole();

            test.Arrange(view, Expr(() => new ConsoleView()));
            console.Act(writer => writer.WriteLine());
            test.Act(Expr(view, v => v.Run()));

            test.Execute();
        }
        #endregion

        #region exercise 3B
        [TestMethod("InputHandler is public delegate"), TestCategory("3B")]
        public void InputHandlerIsPublicDelegate()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertDelegate<InputHandler, Action<string>>(IsPublicDelegate);
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. ConsoleView.Input is public event"), TestCategory("3C")]
        public void ConsoleViewInputIsPublicEvent()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent<ConsoleView, InputHandler>(GetEventInfo<BankAccount>("Input"), IsPublicEvent);
            test.Execute();
        }

        [TestMethod("b. ConsoleView.Run emits Input on non-empty-line input"), TestCategory("3C")]
        public void ConsoleViewRunEmitsInputOnNonEmptyLineInput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> view = test.CreateVariable<ConsoleView>();
            TestConsole console = test.CaptureConsole();

            test.Arrange(view, Expr(() => new ConsoleView()));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<ConsoleView, InputHandler>("Input"));
            console.Act(writer => writer.WriteLine("User input"));
            console.Act(writer => writer.WriteLine());
            test.Act(Expr(view, v => v.Run()));
            test.Execute();
        }

        [TestMethod("c. ConsoleView.Run does not emit Input on empty-line input"), TestCategory("3C")]
        public void ConsoleViewRunDoesNotEmitInputOnEmptyLineInput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> view = test.CreateVariable<ConsoleView>();
            TestConsole console = test.CaptureConsole();

            test.Arrange(view, Expr(() => new ConsoleView()));
            test.DelegateAssert.IsNotInvoked(LambdaSubscribe<ConsoleView, InputHandler>("Input"));
            console.Act(writer => writer.WriteLine());
            test.Act(Expr(view, v => v.Run()));
            test.Execute();
        }
        #endregion
    }
}
