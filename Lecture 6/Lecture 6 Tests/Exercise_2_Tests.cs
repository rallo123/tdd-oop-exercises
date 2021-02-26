using Lecture_6_Solutions;
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

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_2_Tests 
    {
        #region Exercise 2A
        [TestMethod("a. Car.ID is public read-only int property"), TestCategory("2A")]
        public void CarIDIsPublicReadOnlyIntProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Car, int>(c => c.ID);
            test.Execute();
        }

        [TestMethod("b. Car.ID increases by 1 for each new person"), TestCategory("2A")]
        public void CarIDIncreasesBy1ForEachNewPerson()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            test.Arrange(_car1, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("", "", 0.0M)));
            test.Assert.IsTrue(Expr(_car1, _car2, (c1, c2) => c1.ID + 1 == c2.ID));
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Car.Make is public read-only string property"), TestCategory("2B")]
        public void CarMakeIsPublicReadOnlyStringProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Car, string>(c => c.Make);
            test.Execute();
        }

        [TestMethod("b. Car.Model is public read-only string property"), TestCategory("2B")]
        public void CarModelIsPublicReadOnlyStringProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Car, string>(c => c.Model);
            test.Execute();
        }

        [TestMethod("c. Car.Price is public decimal read-only property"), TestCategory("2B")]
        public void CarPriceIsPublicDecimalReadOnlyProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Car, decimal>(c => c.Price);
            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("a. Car implements IComparable"), TestCategory("2C")]
        public void CarImplementsIcomparable()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Car>(
                new TypeAccessLevelVerifier(AccessLevels.Public),
                new TypeIsSubclassOfVerifier(typeof(IComparable)));
            test.Execute();
        }

        [TestMethod("b. Car.CompareTo sorts null first"), TestCategory("2C")]
        public void CarCompareToSortsNullFirst()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car = test.CreateVariable<Car>();
            test.Arrange(_car, Expr(() => new Car("", "", 0.0M)));
            test.Assert.IsTrue(Expr(_car, c => c.CompareTo(null) < 0));
            test.Execute();
        }

        [TestMethod("c. Car.CompareTo sorts higher ID first"), TestCategory("2C")]
        public void CarCompareToSortsHigherIDFirst()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            test.Arrange(_car1, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("", "", 0.0M)));
            test.Assert.IsTrue(Expr(_car1, _car2, (c1, c2) => c2.CompareTo(c1) < 0));
            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("a. CarPriceComparer implements IComparer<Car>"), TestCategory("2D")]
        public void CarPriceComparerImplementsIComparerCar()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<CarPriceComparer>(
                new TypeAccessLevelVerifier(AccessLevels.Public),
                new TypeIsSubclassOfVerifier(typeof(IComparer<Car>)));
            test.Execute();
        }

        [TestMethod("b. CarPriceComparer.Compare sorts null first"), TestCategory("2D")]
        public void CarPriceComparerCompareSortsNullFirst()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car = test.CreateVariable<Car>();
            TestVariable<CarPriceComparer> _comparer = test.CreateVariable<CarPriceComparer>();
            test.Arrange(_car, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car, (c1, c2) => c1.Compare(c2, null) < 0));
            test.Execute();
        }

        [TestMethod("c. CarPriceComparer.Compare sorts cars with higher Price first"), TestCategory("2D")]
        public void CarPriceComparerCompareSortsCarsWithHigherPriceFirst()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarPriceComparer> _comparer = test.CreateVariable<CarPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("", "", 1.0M)));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) < 0));
            test.Execute();
        }

        [TestMethod("d. CarPriceComparer.Compare does not sort cars if equal Price"), TestCategory("2D")]
        public void CarPriceComparerCompareDoesNotSortCarsIfEqualPrice()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarPriceComparer> _comparer = test.CreateVariable<CarPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) == 0));
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("a. CarMakeModelPriceComparer implements IComparer<Car>"), TestCategory("2E")]
        public void Test2E1()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<CarMakeModelPriceComparer>(
                new TypeAccessLevelVerifier(AccessLevels.Public),
                new TypeIsSubclassOfVerifier(typeof(IComparer<Car>)));
            test.Execute();
        }

        [TestMethod("b. CarMakeModelPriceComparer.Compare sorts null first"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsNullFirst()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car = test.CreateVariable<Car>();
            TestVariable<CarMakeModelPriceComparer> _comparer = test.CreateVariable<CarMakeModelPriceComparer>();
            test.Arrange(_car, Expr(() => new Car("", "", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarMakeModelPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car, (c1, c2) => c1.Compare(c2, null) < 0));
            test.Execute();
        }

        [TestMethod("c. CarMakeModelPriceComparer.Compare sorts according to Car.Make"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarMake()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarMakeModelPriceComparer> _comparer = test.CreateVariable<CarMakeModelPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("Audi", "", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("BMW", "", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarMakeModelPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) < 0));
            test.Execute();
        }

        [TestMethod("d. CarMakeModelPriceComparer.Compare sorts according to Car.Model if Car.Make are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarModel()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarMakeModelPriceComparer> _comparer = test.CreateVariable<CarMakeModelPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("Audi", "A3", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("Audi", "S3", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarMakeModelPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) < 0));
            test.Execute();
        }

        [TestMethod("e. CarMakeModelPriceComparer.Compare sorts according to Car.Price if Car.Make and Car.Model are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareSortsAccordingToCarPrice()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarMakeModelPriceComparer> _comparer = test.CreateVariable<CarMakeModelPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("Audi", "A3", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("Audi", "A3", 1.0M)));
            test.Arrange(_comparer, Expr(() => new CarMakeModelPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) < 0));
            test.Execute();
        }

        [TestMethod("f. CarMakeModelPriceComparer.Compare does not sort if Car.Make, Car.Model and Car.Price are equal"), TestCategory("2E")]
        public void CarMakeModelPriceComparerCompareDoesNotSortIfEverythingIsEqual()
        {
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Car> _car1 = test.CreateVariable<Car>();
            TestVariable<Car> _car2 = test.CreateVariable<Car>();
            TestVariable<CarMakeModelPriceComparer> _comparer = test.CreateVariable<CarMakeModelPriceComparer>();
            test.Arrange(_car1, Expr(() => new Car("Audi", "A3", 0.0M)));
            test.Arrange(_car2, Expr(() => new Car("BMW", "A3", 0.0M)));
            test.Arrange(_comparer, Expr(() => new CarMakeModelPriceComparer()));
            test.Assert.IsTrue(Expr(_comparer, _car1, _car2, (c1, c2, c3) => c1.Compare(c2, c3) == 0));
            test.Execute();
        }
        #endregion
    }
}
