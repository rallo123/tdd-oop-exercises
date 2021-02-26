using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
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
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyField<Pair<string, int>, string>(p => p.Fst); 
            test.AssertPublicReadonlyField<Pair<double, int>, double>(p => p.Fst);
            test.Execute();
        }

        [TestMethod("b. Snd is public read-only T2 property"), TestCategory("1A")]
        public void SndIsPublicReadOnlyT2Property()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest(); 
            test.AssertPublicReadonlyField<Pair<string, int>, int>(p => p.Snd);
            test.AssertPublicReadonlyField<Pair<string, double>, double>(p => p.Snd);
            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("a. Pair has constructor that takes T1 argument and T2 argument"), TestCategory("1B")]
        public void PairHasCorrectConstructor()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, int, Pair<string, int>>((v1, v2) => new Pair<string, int>(v1, v2));
            test.AssertPublicConstructor<string, double, Pair<string, double>>((v1, v2) => new Pair<string, double>(v1, v2));
            test.Execute();
        }

        [TestMethod("b. Pair constructor sets Fst"), TestCategory("1B")]
        public void PairConstructorSetsFst()
        {
            Pair<string, int> pair = new Pair<string, int>("abc", 5);
            Assert.AreEqual(pair.Fst, "abc");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> _pair = test.CreateVariable<Pair<string, int>>();
            test.Arrange(_pair, Expr(() => new Pair<string, int>("abc", 5)));
            test.Assert.AreEqual(Expr(_pair, p => p.Fst), Const("abc"));
            test.Execute();
        }

        [TestMethod("c. Pair constructor sets Snd"), TestCategory("1B")]
        public void PairConstructorSetsSnd()
        {
            Pair<string, int> pair = new Pair<string, int>("abc", 5);
            Assert.AreEqual(pair.Snd, 5);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> _pair = test.CreateVariable<Pair<string, int>>();
            test.Arrange(_pair, Expr(() => new Pair<string, int>("abc", 5)));
            test.Assert.AreEqual(Expr(_pair, p => p.Snd), Const(5));
            test.Execute();
        }
        #endregion

        #region Exercise 1C
        [TestMethod("a. Pair.Swap() is public method"), TestCategory("1C")]
        public void PairSwapIsPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<Pair<string, int>, Pair<int, string>>(p => p.Swap());
            test.AssertPublicMethod<Pair<string, double>, Pair<double, string>>(p => p.Swap());
            test.Execute();
        }
        
        [TestMethod("b. Pair.Swap() switches Fst and Snd values"), TestCategory("1C")]
        public void PairSwapSwitchesFstAndSnd()
        {
            Pair<string, int> pair1 = new Pair<string, int>("abc", 5);

            Pair<int, string> pair2 = pair1.Swap();

            Assert.AreEqual(pair2.Fst, 5);
            Assert.AreEqual(pair2.Snd, "abc");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> _pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<int, string>> _pair2 = test.CreateVariable<Pair<int, string>>();
            test.Arrange(_pair1, Expr(() => new Pair<string, int>("abc", 5)));
            test.Arrange(_pair2, Expr(_pair1, p => p.Swap()));
            test.Assert.AreEqual(Expr(_pair2, p => p.Fst), Const(5));
            test.Assert.AreEqual(Expr(_pair2, p => p.Snd), Const("abc"));
            test.Execute();
        }
        #endregion

        #region Exercise 1D
        [TestMethod("a. Pair.SetFst(C value) is public method")]
        public void PairSetFstIsPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<Pair<string, int>, double, Pair<double, int>>((p, d) => p.SetFst(d));
            test.Execute();
        }

        [TestMethod("b. Pair.SetSnd(C value) is public method")]
        public void PairSetSndIsPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<Pair<string, int>, double, Pair<string, double>>((p, d) => p.SetSnd(d));
            test.Execute();
        }

        [TestMethod("c. Pair.SetFst(C value) returns new Pair with Fst = value")]
        public void PairSetFstReturnsNewPair()
        {
            Pair<string, int> pair1 = new Pair<string, int>("abc", 5);

            Pair<double, int> pair2 = pair1.SetFst(7.0);

            Assert.AreEqual(pair2.Fst, 7.0);
            Assert.AreEqual(pair2.Snd, 5);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> _pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<double, int>> _pair2 = test.CreateVariable<Pair<double, int>>();
            test.Arrange(_pair1, Expr(() => new Pair<string, int>("abc", 5)));
            test.Arrange(_pair2, Expr(_pair1, p => p.SetFst(7.0)));
            test.Assert.AreEqual(Expr(_pair2, p => p.Fst), Const(7.0));
            test.Assert.AreEqual(Expr(_pair2, p => p.Snd), Const(5));
            test.Execute();
        }

        [TestMethod("c. Pair.SetSnd(C value) returns new Pair with Snd = value")]
        public void PairSetSndReturnsNewPair()
        {
            Pair<string, int> pair1 = new Pair<string, int>("abc", 5);

            Pair<string, double> pair2 = pair1.SetSnd(7.0);

            Assert.AreEqual(pair2.Fst, "abc");
            Assert.AreEqual(pair2.Snd, 7.0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Pair<string, int>> _pair1 = test.CreateVariable<Pair<string, int>>();
            TestVariable<Pair<string, double>> _pair2 = test.CreateVariable<Pair<string, double>>();
            test.Arrange(_pair1, Expr(() => new Pair<String, int>("abc", 5)));
            test.Arrange(_pair2, Expr(_pair1, p => p.SetSnd(7.0)));
            test.Assert.AreEqual(Expr(_pair2, p => p.Fst), Const("abc"));
            test.Assert.AreEqual(Expr(_pair2, p => p.Snd), Const(7.0));
            test.Execute();
        }
        #endregion
    }
}
