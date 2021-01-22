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
using System.Linq;

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_5_Tests 
    {
        #region Exercise 5A
        [TestMethod("a. CarListSorter.Comparer is a publuc IComparer<Car> property"), TestCategory("5A")]
        public void CarListSorterComparerIsPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<CarSorter, IComparer<Car>>(c => c.Comparer, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. CarSorter.Comparer initializes to null"), TestCategory("5A")]
        public void CarSorterComparerInitializesToNull()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<CarSorter> sorter = test.CreateObject<CarSorter>();

            sorter.Arrange(() => new CarSorter());
            sorter.Assert.IsTrue(s => s.Comparer == null);

            test.Execute();
        }
        #endregion

        #region Exercise 5B
        [TestMethod("a. CarListSorter.Sort takes an array of cars"), TestCategory("5B")]
        public void DieConstructorTakesIRandomAndInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<CarSorter, Car[]>((c1, c2) => c1.Sort(c2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. CarListSorter.Sort does not sort array if Comparer = null"), TestCategory("5B")]
        public void CarListSorterSortDoesNotSort()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<CarSorter> sorter = test.CreateObject<CarSorter>();
            UnitTestObject<Car[]> carsBefore = test.CreateObject<Car[]>();
            UnitTestObject<Car[]> carsAfter = test.CreateObject<Car[]>();

            sorter.Arrange(() => new CarSorter());
            carsBefore.Arrange(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) });
            carsAfter.Arrange(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) });
            sorter.WithParameters(carsBefore).Act((s, c) => s.Sort(c));
            carsBefore.WithParameters(carsAfter).Assert.IsTrue((c1, c2) => c1.SequenceEqual(c2));

            test.Execute();
        }

        [TestMethod("c. CarListSorter.Sort sorts according to price if Comparer = new CarPriceComparer()"), TestCategory("5B")]
        public void CarListSorterSorts()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<CarSorter> sorter = test.CreateObject<CarSorter>();
            UnitTestObject<Car[]> carsBefore = test.CreateObject<Car[]>();
            UnitTestObject<Car[]> carsAfter = test.CreateObject<Car[]>();

            sorter.Arrange(() => new CarSorter() { Comparer = new CarPriceComparer() });
            carsBefore.Arrange(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) });
            carsAfter.Arrange(() => new[] {
                new Car("Suzuki", "Splash", 123467.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Audi", "S3", 1234567.0M),
            });
            sorter.WithParameters(carsBefore).Act((s, c) => s.Sort(c));
            carsBefore.WithParameters(carsAfter).Assert.IsTrue((c1, c2) => c1.SequenceEqual(c2));

            test.Execute();
        }
        #endregion

    }
}
