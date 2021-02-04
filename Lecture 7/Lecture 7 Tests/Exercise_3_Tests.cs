using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_3_Tests {
        #region Exercise 3A
        [TestMethod("Dog has a public default constructor"), TestCategory("3A")]
        public void DogHasPublicDefaultConstructor()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Dog>(() => new Dog(), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("Dog.ID is public property"), TestCategory("3A")]
        public void DogIDIsPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Dog, int>(d => d.ID, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("Dog.Name has is public property"), TestCategory("3A")]
        public void DogNameIsPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Dog, string>(d => d.Name, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("Dog.Breed has is public property"), TestCategory("3A")]
        public void DogBreedIsPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Dog, string>(d => d.Breed, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("Dog.Age has is public property"), TestCategory("3A")]
        public void DogAgeIsPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Dog, int>(d => d.Age, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("Dog.ID = -1 throws ArgumentException"), TestCategory("3A")]
        public void DogIDAssignmentOfMinus1ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> dog = test.CreateVariable<Dog>();

            test.Arrange(dog, Expr(() => new Dog()));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, int>(Expr(dog, d => d.ID), Const(-1));

            test.Execute();
        }

        [TestMethod("Dog.Age = -1 throws ArgumentException"), TestCategory("3A")]
        public void DogAgeAssignmentOfMinus1ThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> dog = test.CreateVariable<Dog>();

            test.Arrange(dog, Expr(() => new Dog()));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, int>(Expr(dog, d => d.Age), Const(-1));

            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("Dog implements ICloneable"), TestCategory("3B")]
        public void MyQueueCountIsReadOnlyIntProoerty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Dog>(HasClassImplementedInterface(typeof(ICloneable)));
            test.Execute();
        }

        [TestMethod("Dog.Clone() clones fields")]
        public void MyQueueCountIsInitializedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> dog1 = test.CreateVariable<Dog>();
            TestVariable<Dog> dog2 = test.CreateVariable<Dog>();

            test.Arrange(dog1, Expr(() => new Dog() { ID = 5, Name = "Buddy", Breed = "Labrador", Age = 4 }));
            test.Arrange(dog2, Expr(dog1, d => (Dog)d.Clone()));
            test.Assert.AreEqual(Expr(dog2, d => d.ID), Const(5));
            test.Assert.AreEqual(Expr(dog2, d => d.Name), Const("Buddy"));
            test.Assert.AreEqual(Expr(dog2, d => d.Breed), Const("Labrador"));
            test.Assert.AreEqual(Expr(dog2, d => d.Age), Const(4));

            test.Execute();
        }
        #endregion
    }
}
