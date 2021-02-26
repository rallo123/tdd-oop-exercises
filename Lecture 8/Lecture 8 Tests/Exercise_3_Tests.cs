using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
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
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ConsoleView>(v => v.Run());
            test.Execute();
        }

        [TestMethod("BankAccount.Run() returns on empty line input"), TestCategory("3A")]
        public void BankAccount()
        {
            // MSTest Extended
            ConsoleView view = new ConsoleView();
            
            ConsoleInputter.WriteLine();
            view.Run();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> _view = test.CreateVariable<ConsoleView>();
            test.Arrange(_view, Expr(() => new ConsoleView()));
            test.Act(Expr(() => ConsoleInputter.WriteLine()));
            test.Act(Expr(_view, v => v.Run()));
            test.Execute();
        }
        #endregion

        #region exercise 3B
        [TestMethod("InputHandler is public delegate"), TestCategory("3B")]
        public void InputHandlerIsPublicDelegate()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicDelegate<InputHandler, Action<string>>();
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. ConsoleView.Input is public event"), TestCategory("3C")]
        public void ConsoleViewInputIsPublicEvent()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent(
                typeof(BankAccount).GetEvent("Input"),
                new MemberAccessLevelVerifier(AccessLevels.Public),
                new EventHandlerTypeVerifier(typeof(InputHandler)));
            test.Execute();
        }

        [TestMethod("b. ConsoleView.Run emits Input on non-empty-line input"), TestCategory("3C")]
        public void ConsoleViewRunEmitsInputOnNonEmptyLineInput()
        {
            ConsoleView view = new ConsoleView();
            DelegateAssert.IsInvoked<InputHandler>(handler => view.Input += handler);
            
            ConsoleInputter.WriteLine("User input");
            ConsoleInputter.WriteLine();
            view.Run();

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> _view = test.CreateVariable<ConsoleView>();
            test.Arrange(_view, Expr(() => new ConsoleView()));
            test.DelegateAssert.IsInvoked(Lambda<InputHandler>(handler => Expr(_view, v => v.AddInput(handler))));
            test.Act(Expr(() => ConsoleInputter.WriteLine("User input")));
            test.Act(Expr(() => ConsoleInputter.WriteLine()));
            test.Act(Expr(_view, v => v.Run()));
            test.Execute();
        }

        [TestMethod("c. ConsoleView.Run does not emit Input on empty-line input"), TestCategory("3C")]
        public void ConsoleViewRunDoesNotEmitInputOnEmptyLineInput()
        {
            ConsoleView view = new ConsoleView();
            DelegateAssert.IsNotInvoked<InputHandler>(handler => view.Input += handler);

            ConsoleInputter.WriteLine();
            view.Run();

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<ConsoleView> _view = test.CreateVariable<ConsoleView>();
            test.Arrange(_view, Expr(() => new ConsoleView()));
            test.DelegateAssert.IsNotInvoked(Lambda<InputHandler>(handler => Expr(_view, v => v.AddInput(handler))));
            test.Act(Expr(() => ConsoleInputter.WriteLine()));
            test.Act(Expr(_view, v => v.Run()));
            test.Execute();
        }
        #endregion
    }
}
