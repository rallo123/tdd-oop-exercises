using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using System.Linq;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        #region Exercise 1A
        [TestMethod("a. Fst is public read-only T1 property"), TestCategory("1A")]
        public void FstIsPublicReadOnlyT1Property()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertField<Pair<string, int>, string>(p => p.Fst, IsPublicReadOnlyField); 
            test.AssertField<Pair<double, int>, double>(p => p.Fst, IsPublicReadOnlyField);
            test.Execute();
        }

        [TestMethod("b. Snd is public read-only T2 property"), TestCategory("1A")]
        public void SndIsPublicReadOnlyT2Property()
        {
            StructureTest test = Factory.CreateStructureTest(); 
            test.AssertField<Pair<string, int>, int>(p => p.Snd, IsPublicReadOnlyField);
            test.AssertField<Pair<string, double>, double>(p => p.Snd, IsPublicReadOnlyField);
            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("a. Pair has constructor that takes T1 argument and T2 argument"), TestCategory("1B")]
        public void PairHasCorrectConstructor()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<string, int, Pair<string, int>>((v1, v2) => new Pair<string, int>(v1, v2), IsPublicConstructor);
            test.AssertConstructor<string, double, Pair<string, double>>((v1, v2) => new Pair<string, double>(v1, v2), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("b. Pair constructor sets Fst"), TestCategory("1B")]
        public void PairConstructorSetsFst()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> pair = test.CreateVariable<Pair<string, int>>();

            test.Arrange(pair, Expr(() => new Pair<string, int>("abc", 5)));
            test.Assert.AreEqual(Expr(pair, p => p.Fst), Const("abc"));

            test.Execute();
        }

        [TestMethod("c. Pair constructor sets Snd"), TestCategory("1B")]
        public void PairConstructorSetsSnd()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> pair = test.CreateVariable<Pair<string, int>>();

            test.Arrange(pair, Expr(() => new Pair<string, int>("abc", 5)));
            test.Assert.AreEqual(Expr(pair, p => p.Snd), Const(5));

            test.Execute();
        }
        #endregion

        #region Exercise 1C
        [TestMethod("a. Pair.Swap() is public method"), TestCategory("1C")]
        public void PairSwapIsPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Pair<string, int>, Pair<int, string>>(p => p.Swap(), IsPublicMethod);
            test.AssertMethod<Pair<string, double>, Pair<double, string>>(p => p.Swap(), IsPublicMethod);
            test.Execute();
        }
        
        [TestMethod("b. Pair.Swap() switches Fst and Snd values"), TestCategory("1C")]
        public void PairSwapSwitchesFstAndSnd()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<int, string>> pair2 = test.CreateVariable<Pair<int, string>>();

            test.Arrange(pair1, Expr(() => new Pair<string, int>("abc", 5)));
            test.Arrange(pair2, Expr(pair1, p => p.Swap()));
            test.Assert.AreEqual(Expr(pair2, p => p.Fst), Const(5));
            test.Assert.AreEqual(Expr(pair2, p => p.Snd), Const("abc"));

            test.Execute();
        }
        #endregion

        #region Exercise 1D
        [TestMethod("a. Pair.SetFst(C value) is public method")]
        public void PairSetFstIsPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Pair<string, int>, double, Pair<double, int>>((p, d) => p.SetFst(d), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. Pair.SetSnd(C value) is public method")]
        public void PairSetSndIsPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Pair<string, int>, double, Pair<string, double>>((p, d) => p.SetSnd(d), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. Pair.SetFst(C value) returns new Pair with Fst = value")]
        public void PairSetFstReturnsNewPair()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<double, int>> pair2 = test.CreateVariable<Pair<double, int>>();

            test.Arrange(pair1, Expr(() => new Pair<string, int>("abc", 5)));
            test.Arrange(pair2, Expr(pair1, p => p.SetFst(7.0)));
            test.Assert.AreEqual(Expr(pair2, p => p.Fst), Const(7.0));
            test.Assert.AreEqual(Expr(pair2, p => p.Snd), Const(5));

            test.Execute();
        }

        [TestMethod("c. Pair.SetSnd(C value) returns new Pair with Snd = value")]
        public void PairSetSndReturnsNewPair()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<string, double>> pair2 = test.CreateVariable<Pair<string, double>>();

            test.Arrange(pair1, Expr(() => new Pair<String, int>("abc", 5)));
            test.Arrange(pair2, Expr(pair1, p => p.SetSnd(7.0)));
            test.Assert.AreEqual(Expr(pair2, p => p.Fst), Const("abc"));
            test.Assert.AreEqual(Expr(pair2, p => p.Snd), Const(7.0));

            test.Execute();
        }
        #endregion
    }
}
