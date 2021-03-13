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
    public class Exercise_5_Tests 
    {
        #region Exercise 5A
        [TestMethod("a. CarListSorter.Comparer is a publuc IComparer<Car> property"), TestCategory("5A")]
        public void CarListSorterComparerIsPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<CarSorter, IComparer<Car>>(c => c.Comparer);
            test.Execute();
        }

        [TestMethod("b. CarSorter.Comparer initializes to null"), TestCategory("5A")]
        public void CarSorterComparerInitializesToNull()
        {
            CarSorter sorter = new CarSorter();
            Assert.IsNull(sorter.Comparer);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<CarSorter> _sorter = test.CreateVariable<CarSorter>();
            test.Arrange(_sorter, Expr(() => new CarSorter()));
            test.Assert.IsNull(Expr(_sorter, s => s.Comparer));
            test.Execute();
        }
        #endregion

        #region Exercise 5B
        [TestMethod("a. CarListSorter.Sort takes an array of cars"), TestCategory("5B")]
        public void DieConstructorTakesIRandomAndInt()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<CarSorter, Car[]>((c1, c2) => c1.Sort(c2));
            test.Execute();
        }

        [TestMethod("b. CarListSorter.Sort does not sort array if Comparer = null"), TestCategory("5B")]
        public void CarListSorterSortDoesNotSort()
        {
            // FAILS AT THE MOMENT AND MORE WORK IS NEEDED ON THIS
            CarSorter sorter = new CarSorter();
            Car[] carsBefore = new Car[]
            {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) 
            };
            Car[] carsAfter = new Car[]
            {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M)
            };

            sorter.Sort(carsBefore);

            Assert.IsTrue(carsBefore.SequenceEqual(carsAfter));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<CarSorter> _sorter = test.CreateVariable<CarSorter>();
            TestVariable<Car[]> _carsBefore = test.CreateVariable<Car[]>();
            TestVariable<Car[]> _carsAfter = test.CreateVariable<Car[]>();
            test.Arrange(_sorter, Expr(() => new CarSorter()));
            test.Arrange(_carsBefore, Expr(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) }));
            test.Arrange(_carsAfter, Expr(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) }));
            test.Act(Expr(_sorter, _carsBefore, (s, c) => s.Sort(c)));
            test.Assert.IsTrue(Expr(_carsBefore, _carsAfter, (c1, c2) => c1.SequenceEqual(c2)));
            test.Execute();
        }

        [TestMethod("c. CarListSorter.Sort sorts according to price if Comparer = new CarPriceComparer()"), TestCategory("5B")]
        public void CarListSorterSorts()
        {
            // FAILS AT THE MOMENT AND MORE WORK IS NEEDED ON THIS
            CarSorter sorter = new CarSorter() 
            {
                Comparer = new CarPriceComparer()
            };
            Car[] carsBefore = new Car[]
            {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M)
            };
            Car[] carsAfter = new Car[]
            {
                new Car("Suzuki", "Splash", 123467.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Audi", "S3", 1234567.0M)
            };

            sorter.Sort(carsBefore);

            Assert.IsTrue(carsBefore.SequenceEqual(carsAfter));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<CarSorter> _sorter = test.CreateVariable<CarSorter>();
            TestVariable<Car[]> _carsBefore = test.CreateVariable<Car[]>();
            TestVariable<Car[]> _carsAfter = test.CreateVariable<Car[]>();
            test.Arrange(_sorter, Expr(() => new CarSorter() { Comparer = new CarPriceComparer() }));
            test.Arrange(_carsBefore, Expr(() => new[] {
                new Car("Audi", "S3", 1234567.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Suzuki", "Splash", 123467.0M) }));
            test.Arrange(_carsAfter, Expr(() => new[] {
                new Car("Suzuki", "Splash", 123467.0M),
                new Car("Audi", "S4", 123464.0M),
                new Car("Audi", "S3", 1234567.0M),
            }));
            test.Act(Expr(_sorter, _carsBefore, (s, c) => s.Sort(c)));
            test.Assert.IsTrue(Expr(_carsBefore, _carsAfter, (c1, c2) => c1.SequenceEqual(c2)));
            test.Execute();
        }
        #endregion
    }
}
