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

        [TestMethod("Temperature.Kelvin is public double property"), TestCategory("1A")]
        public void TemperatureKelvinIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Temperature, double>(t => t.Kelvin, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("Temperature.Celcius = -276.0 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureCelciusAssignmentOfMinus276ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Assert.ThrowsException<ArgumentException>(Assignment<Temperature, double>(t => t.Celcius, -276.0));

            test.Execute();
        }

        [TestMethod("Temperature.Fahrenheit = -460.0 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureFahrenheitAssignmentOfMinus460ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Assert.ThrowsException<ArgumentException>(Assignment<Temperature, double>(t => t.Fahrenheit, -460));

            test.Execute();
        }

        [TestMethod("Temperature.Kelvin = -1 throws ArgumentException"), TestCategory("1A")]
        public void TemperatureKelvinAssignmentOfMinus1ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Assert.ThrowsException<ArgumentException>(Assignment<Temperature, double>(t => t.Kelvin, -1));

            test.Execute();
        }

        [TestMethod("Temperature.Kelvin equals 0 after Temperature.Celcius = -275"), TestCategory("1A")]
        public void TemperatureKelvinEquals0AfterTemperatureCelciusAssignmentOfMinus275()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Act(Assignment<Temperature, double>(t => t.Celcius, -275.15));
            temperature.Assert.IsTrue(t => t.Kelvin == 0);

            test.Execute();
        }

        [TestMethod("Temperature.Kelvin equals 0 after Temperature.Fahrenheit = -459.67"), TestCategory("1A")]
        public void TemperatureKelvinEquals0AfterTemperatureFahrenheitAssignmentOfMinus459()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Act(Assignment<Temperature, double>(t => t.Fahrenheit, -459.67));
            temperature.Assert.IsTrue(t => t.Kelvin == 0);

            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("Temperature implements IComparable"), TestCategory("1B")]
        public void TemperatureImplementsIComparable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Temperature>(t => t.GetInterface("IComparable") != null);
            test.Execute();
        }

        [TestMethod("Temperature.CompareTo sorts null first"), TestCategory("1B")]
        public void TemperatureCompareToSortsNullFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature = test.CreateObject<Temperature>();

            temperature.Arrange(() => new Temperature());
            temperature.Assert.IsTrue(t => t.CompareTo(null) > 0);
            test.Execute();
        }

        [TestMethod("Temperature.CompareTo sorts higher temperature first"), TestCategory("1B")]
        public void TemperatureCompareToSortsHigherTemperatureFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature1 = test.CreateObject<Temperature>();
            UnitTestObject<Temperature> temperature2 = test.CreateObject<Temperature>();

            temperature1.Arrange(() => new Temperature() { Kelvin = 0 });
            temperature2.Arrange(() => new Temperature() { Kelvin = 1 });
            temperature1.WithParameters(temperature2).Assert.IsTrue((t1, t2) => t1.CompareTo(t2) < 0);
            test.Execute();
        }

        [TestMethod("Temperature.CompareTo does not sort equal temperatures"), TestCategory("1B")]
        public void Test1B4()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Temperature> temperature1 = test.CreateObject<Temperature>();
            UnitTestObject<Temperature> temperature2 = test.CreateObject<Temperature>();

            temperature1.Arrange(() => new Temperature() { Kelvin = 0 });
            temperature2.Arrange(() => new Temperature() { Kelvin = 0 });
            temperature1.WithParameters(temperature2).Assert.IsTrue((t1, t2) => t1.CompareTo(t2) == 0);
            test.Execute();
        }
        #endregion
    }
}
