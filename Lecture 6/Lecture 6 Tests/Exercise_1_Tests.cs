using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.StructureTests;
using TestTools.UnitTests;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        #region Exercise 1A
        [TestMethod("a. Temperature.Celcius is public double property"), TestCategory("1A")]
        public void TemperatureCelciusIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Temperature, double>(t => t.Celcius, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Temperature.Fahrenheit is public double property"), TestCategory("1A")]
        public void TemperatureFahrenheitIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Temperature, double>(t => t.Fahrenheit, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Temperature.Kelvin is public double property"), TestCategory("1A")]
        public void TemperatureKelvinIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Temperature, double>(t => t.Kelvin, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. Temperature.Celcius = -276.0 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureCelciusAssignmentOfMinus276ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, double>(Expr(temperature, t => t.Celcius), Const(-276.0));

            test.Execute();
        }

        [TestMethod("e. Temperature.Fahrenheit = -460.0 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureFahrenheitAssignmentOfMinus460ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, double>(Expr(temperature, t => t.Fahrenheit), Const(-460.0));

            test.Execute();
        }

        [TestMethod("f. Temperature.Kelvin = -1 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureKelvinAssignmentOfMinus1ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, double>(Expr(temperature, t => t.Kelvin), Const(-1.0));

            test.Execute();
        }

        [TestMethod("g. Temperature.Kelvin equals 0 after Temperature.Celcius = -275"), TestCategory("1A")]
        public void TemperatureKelvinEquals0AfterTemperatureCelciusAssignmentOfMinus275()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assign(Expr(temperature, t => t.Celcius), Const(-275.15));
            test.Assert.AreEqual(Expr(temperature, t => t.Kelvin), Const(0.0));

            test.Execute();
        }

        [TestMethod("h. Temperature.Kelvin equals 0 after Temperature.Fahrenheit = -459.67"), TestCategory("1A")]
        public void TemperatureKelvinEquals0AfterTemperatureFahrenheitAssignmentOfMinus459()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assign(Expr(temperature, t => t.Fahrenheit), Const(-459.67));
            test.Assert.AreEqual(Expr(temperature, t => t.Kelvin), Const(0.0));

            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("a. Temperature implements IComparable"), TestCategory("1B")]
        public void TemperatureImplementsIComparable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Temperature>(t => t.GetInterface("IComparable") != null);
            test.Execute();
        }

        [TestMethod("b. Temperature.CompareTo sorts null first"), TestCategory("1B")]
        public void TemperatureCompareToSortsNullFirst()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature = test.CreateVariable<Temperature>();

            test.Arrange(temperature, Expr(() => new Temperature()));
            test.Assert.IsTrue(Expr(temperature, t => t.CompareTo(null) < 0));

            test.Execute();
        }

        [TestMethod("c. Temperature.CompareTo sorts higher temperature first"), TestCategory("1B")]
        public void TemperatureCompareToSortsHigherTemperatureFirst()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature1 = test.CreateVariable<Temperature>();
            TestVariable<Temperature> temperature2 = test.CreateVariable<Temperature>();

            test.Arrange(temperature1, Expr(() => new Temperature() { Kelvin = 0 }));
            test.Arrange(temperature2, Expr(() => new Temperature() { Kelvin = 1 }));
            test.Assert.IsTrue(Expr(temperature1, temperature2, (t1, t2) => t1.CompareTo(t2) > 0));

            test.Execute();
        }

        [TestMethod("d. Temperature.CompareTo does not sort equal temperatures"), TestCategory("1B")]
        public void Test1B4()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Temperature> temperature1 = test.CreateVariable<Temperature>();
            TestVariable<Temperature> temperature2 = test.CreateVariable<Temperature>();

            test.Arrange(temperature1, Expr(() => new Temperature() { Kelvin = 0 }));
            test.Arrange(temperature2, Expr(() => new Temperature() { Kelvin = 0 }));
            test.Assert.IsTrue(Expr(temperature1, temperature2, (t1, t2) => t1.CompareTo(t2) == 0));

            test.Execute();
        }
        #endregion
    }
}
