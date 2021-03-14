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
    public class Exercise_3_Tests {
        #region Exercise 3A
        [TestMethod("Dog has a public default constructor"), TestCategory("3A")]
        public void DogHasPublicDefaultConstructor()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<Dog>(() => new Dog());
            test.Execute();
        }

        [TestMethod("Dog.ID is public property"), TestCategory("3A")]
        public void DogIDIsPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Dog, int>(d => d.ID);
            test.Execute();
        }

        [TestMethod("Dog.Name has is public property"), TestCategory("3A")]
        public void DogNameIsPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Dog, string>(d => d.Name);
            test.Execute();
        }

        [TestMethod("Dog.Breed has is public property"), TestCategory("3A")]
        public void DogBreedIsPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Dog, string>(d => d.Breed);
            test.Execute();
        }

        [TestMethod("Dog.Age has is public property"), TestCategory("3A")]
        public void DogAgeIsPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Dog, int>(d => d.Age);
            test.Execute();
        }

        [TestMethod("Dog.ID = -1 throws ArgumentException"), TestCategory("3A")]
        public void DogIDAssignmentOfMinus1ThrowsArgumentException()
        {
            Dog dog = new Dog();
            Assert.ThrowsException<ArgumentException>(() => dog.ID = -1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> _dog = test.CreateVariable<Dog>();
            test.Arrange(_dog, Expr(() => new Dog()));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_dog, d => d.SetID(-1)));
            test.Execute();
        }

        [TestMethod("Dog.Age = -1 throws ArgumentException"), TestCategory("3A")]
        public void DogAgeAssignmentOfMinus1ThrowsArgumentException()
        {
            Dog dog = new Dog();
            Assert.ThrowsException<ArgumentException>(() => dog.Age = -1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> _dog = test.CreateVariable<Dog>();
            test.Arrange(_dog, Expr(() => new Dog()));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_dog, d => d.SetAge(-1)));
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("Dog implements ICloneable"), TestCategory("3B")]
        public void MyQueueCountIsReadOnlyIntProoerty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Dog>(new TypeIsSubclassOfVerifier(typeof(ICloneable)));
            test.Execute();
        }

        [TestMethod("Dog.Clone() clones fields"), TestCategory("3B")]
        public void MyQueueCountIsInitializedAs0()
        {
            Dog dog1 = new Dog()
            {
                ID = 5,
                Name = "Buddy",
                Breed = "Labrador",
                Age = 4
            };

            Dog dog2 = (Dog)dog1.Clone();

            Assert.AreEqual(5, dog2.ID);
            Assert.AreEqual("Buddy", dog2.Name);
            Assert.AreEqual("Labrador", dog2.Breed);
            Assert.AreEqual(4, dog2.Age);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Dog> _dog1 = test.CreateVariable<Dog>();
            TestVariable<Dog> _dog2 = test.CreateVariable<Dog>();
            test.Arrange(_dog1, Expr(() => new Dog() { ID = 5, Name = "Buddy", Breed = "Labrador", Age = 4 }));
            test.Arrange(_dog2, Expr(_dog1, d => (Dog)d.Clone()));
            test.Assert.AreEqual(Const(5), Expr(_dog2, d => d.ID));
            test.Assert.AreEqual(Const("Buddy"), Expr(_dog2, d => d.Name));
            test.Assert.AreEqual(Const("Labrador"), Expr(_dog2, d => d.Breed));
            test.Assert.AreEqual(Const(4), Expr(_dog2, d => d.Age));
            test.Execute();
        }
        #endregion
    }
}
