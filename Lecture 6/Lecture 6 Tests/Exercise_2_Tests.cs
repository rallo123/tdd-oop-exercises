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
    public class Exercise_2_Tests 
    {
        #region Exercise 2A

        [TestMethod("a. Car.ID is public read-only int property"), TestCategory("2A")]
        public void CarIDIsPublicReadOnlyIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Car, int>(c => c.ID, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Car.ID increases by 1 for each new person"), TestCategory("2A")]
        public void CarIDIncreasesBy1ForEachNewPerson()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();

            car1.Arrange(() => new Car("", "", 0.0M));
            car2.Arrange(() => new Car("", "", 0.0M));
            car1.WithParameters(car2).Assert.IsTrue((c1, c2) => c2.ID - c1.ID == 1);

            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("Car.Make is public read-only string property"), TestCategory("2B")]
        public void CarMakeIsPublicReadOnlyStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Car, string>(c => c.Make, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("Car.Model is public read-only string property"), TestCategory("2B")]
        public void CarModelIsPublicReadOnlyStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Car, string>(c => c.Model, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("Car.Price is public decimal read-only property"), TestCategory("2B")]
        public void CarPriceIsPublicDecimalReadOnlyProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Car, decimal>(c => c.Price, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("Car.Make = null throws ArgumentNullException"), TestCategory("2B")]
        public void CarMakeAssignmentOfNullThrowsArgumentNullException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();

            car.Arrange(() => new Car("", "", 0.0M));
            car.Assert.ThrowsException<ArgumentNullException>(Assignment<Car, string>(c => c.Make, null));

            test.Execute();
        }

        [TestMethod("Car.Model = null throws ArgumentNullException"), TestCategory("2B")]
        public void CarModelAssignmentOfNullThrowsArgumentNullException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();

            car.Arrange(() => new Car("", "", 0.0M));
            car.Assert.ThrowsException<ArgumentNullException>(Assignment<Car, string>(c => c.Model, null));

            test.Execute();
        }

        [TestMethod("Car.Price = -1.0M throws ArgumentException"), TestCategory("2B")]
        public void CarPriceAssignmentOfMinus1ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();

            car.Arrange(() => new Car("", "", 0.0M));
            car.Assert.ThrowsException<ArgumentException>(Assignment<Car, decimal>(c => c.Price, -1.0M));

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("Car implements IComparable"), TestCategory("2C")]
        public void CarImplementsIcomparable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Car>(t => t.GetInterface("IComparable") != null);
            test.Execute();
        }

        [TestMethod("Car.CompareTo sorts null first"), TestCategory("2C")]
        public void CarCompareToSortsNullFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();

            car.Arrange(() => new Car("", "", 0.0M));
            car.Assert.IsTrue(c => c.CompareTo(null) > 0);
            test.Execute();
        }

        [TestMethod("Car.CompareTo sorts higher ID first"), TestCategory("2C")]
        public void CarCompareToSortsHigherIDFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();

            car1.Arrange(() => new Car("", "", 0.0M));
            car2.Arrange(() => new Car("", "", 0.0M));
            car1.WithParameters(car2).Assert.IsTrue((c1, c2) => c2.CompareTo(c1) < 0);
            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("CarPriceComparer implements IComparer<Car>"), TestCategory("2D")]
        public void CarPriceComparerImplementsIComparerCar()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<CarPriceComparer>(t => t.GetInterface("IComparer<Car>") != null);
            test.Execute();
        }

        [TestMethod("CarPriceComparer.Compare sorts null first"), TestCategory("2D")]
        public void CarPriceComparerCompareSortsNullFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();
            UnitTestObject<CarPriceComparer> comparer = test.CreateObject<CarPriceComparer>();

            car.Arrange(() => new Car("", "", 0.0M));
            comparer.Arrange(() => new CarPriceComparer());
            comparer.WithParameters(car).Assert.IsTrue((c1, c2) => c1.Compare(c2, null) < 0);
            test.Execute();
        }

        [TestMethod("CarPriceComparer.Compare sorts cars with higher Price first"), TestCategory("2D")]
        public void CarPriceComparerCompareSortsCarsWithHigherPriceFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarPriceComparer> comparer = test.CreateObject<CarPriceComparer>();

            car1.Arrange(() => new Car("", "", 0.0M));
            car2.Arrange(() => new Car("", "", 1.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) < 0);
            test.Execute();
        }

        [TestMethod("CarPriceComparer.Compare does not sort cars if equal Price"), TestCategory("2D")]
        public void CarPriceComparerCompareDoesNotSortCarsIfEqualPrice()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarPriceComparer> comparer = test.CreateObject<CarPriceComparer>();

            car1.Arrange(() => new Car("", "", 0.0M));
            car2.Arrange(() => new Car("", "", 0.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) == 0);
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("CarMakeModelPriceComparer implements IComparer<Car>"), TestCategory("2E")]
        public void Test2E1()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<CarMakeModelPriceComparer>(t => t.GetInterface("IComparer<Car>") != null);
            test.Execute();
        }

        [TestMethod("CarMakeModelPriceComparer.Compare sorts null first"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsNullFirst()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car = test.CreateObject<Car>();
            UnitTestObject<CarMakeModelPriceComparer> comparer = test.CreateObject<CarMakeModelPriceComparer>();

            car.Arrange(() => new Car("", "", 0.0M));
            comparer.Arrange(() => new CarMakeModelPriceComparer());
            comparer.WithParameters(car).Assert.IsTrue((c1, c2) => c1.Compare(c2, null) < 0);
            test.Execute();
        }

        [TestMethod("CarMakeModelPriceComparer.Compare sorts according to Car.Make"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarMake()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarMakeModelPriceComparer> comparer = test.CreateObject<CarMakeModelPriceComparer>();

            car1.Arrange(() => new Car("Audi", "", 0.0M));
            car2.Arrange(() => new Car("BMV", "", 0.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) < 0);
            test.Execute();
        }

        [TestMethod("CarMakeModelPriceComparer.Compare sorts according to Car.Model if Car.Make are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarModel()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarMakeModelPriceComparer> comparer = test.CreateObject<CarMakeModelPriceComparer>();

            car1.Arrange(() => new Car("Audi", "A3", 0.0M));
            car2.Arrange(() => new Car("Audi", "S3", 0.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) < 0);
            test.Execute();
        }

        [TestMethod("CarMakeModelPriceComparer.Compare sorts according to Car.Price if Car.Make and Car.Model are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarPrice()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarMakeModelPriceComparer> comparer = test.CreateObject<CarMakeModelPriceComparer>();

            car1.Arrange(() => new Car("Audi", "A3", 0.0M));
            car2.Arrange(() => new Car("Audi", "A3", 1.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) > 0);
            test.Execute();
        }

        [TestMethod("CarMakeModelPriceComparer.Compare does not sort if Car.Make, Car.Model and Car.Price are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareDoesNotSortIfEverythingIsEqual()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Car> car1 = test.CreateObject<Car>();
            UnitTestObject<Car> car2 = test.CreateObject<Car>();
            UnitTestObject<CarMakeModelPriceComparer> comparer = test.CreateObject<CarMakeModelPriceComparer>();

            car1.Arrange(() => new Car("Audi", "A3", 0.0M));
            car2.Arrange(() => new Car("Audi", "A3", 0.0M));
            comparer.WithParameters(car1, car2).Assert.IsTrue((c1, c2, c3) => c1.Compare(c2, c3) == 0);
            test.Execute();
        }
        #endregion
    }
}
