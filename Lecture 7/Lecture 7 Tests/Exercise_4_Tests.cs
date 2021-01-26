using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4a
        [TestMethod("Repository has a constructor that takes ILogger"), TestCategory("4A")]
        public void RepositoryHasPublicDefaultConstructorThatTakesILogger()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Repository<ICloneable>>(() => new Repository<ICloneable>(), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("Repository has a default constructor"), TestCategory("4A")]
        public void RepositoryHasPublicDefaultConstructor()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<ILogger, Repository<ICloneable>>(i => new Repository<ICloneable>(i), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 4b
        [TestMethod("Repository.Add() takes TEntity and adds it to list of entities"), TestCategory("4B")]
        public void RepositoryAddTakesTEntityAndAddsToEntities()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Repository<Dog>> repository = test.CreateObject<Repository<Dog>>();

            repository.Arrange(() => new Repository<Dog>());
            repository.Act(r => r.Add(new Dog()));
            repository.Assert.IsTrue(r => r.GetAll().Count == 1);

            test.Execute();
        }
        #endregion

        #region Exercise 4c
        [TestMethod("Repository.GetAll() takes nothing and returns list of all entities"), TestCategory("4C")]
        public void RepositoryGetAllReturnsListOfEntities()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Repository<Dog>> repository = test.CreateObject<Repository<Dog>>();

            repository.Arrange(() => new Repository<Dog>());
            repository.Act(r => r.Add(new Dog()));
            repository.Act(r => r.Add(new Dog()));
            repository.Assert.IsTrue(r => r.GetAll().Count == 2);

            test.Execute();
        }
        #endregion

        #region Exercise 4d
        [TestMethod("Repository.Update(TEntity, TEntity) updates an entity"), TestCategory("4d")]
        public void RepositoryUpdateUpdatesAnEntity()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Repository<Dog>> repository = test.CreateObject<Repository<Dog>>();
            UnitTestObject<Dog> oldDog = test.CreateObject<Dog>();
            UnitTestObject<Dog> newDog = test.CreateObject<Dog>();

            repository.Arrange(() => new Repository<Dog>());
            oldDog.Arrange(() => new Dog() { ID = 2 });
            newDog.Arrange(() => new Dog() { ID = 3 });
            repository.Act(r => r.Add(new Dog() { ID = 1 }));
            repository.WithParameters(oldDog).Act((r, d) => r.Add(d));
            repository.WithParameters(oldDog, newDog).Act((r, oldD, newD) => r.Update(oldD, newD));
            repository.WithParameters(newDog).Assert.IsTrue((r, d) => r.GetAll()[1].Equals(d));

            test.Execute();
        }
        #endregion

        #region Exercise 4e
        [TestMethod("Repository.Delete(TEntity) Deletes an entity"), TestCategory("4e")]
        public void RepositoryDeleteDeletesAnEntity()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Repository<Dog>> repository = test.CreateObject<Repository<Dog>>();
            UnitTestObject<Dog> dog = test.CreateObject<Dog>();

            repository.Arrange(() => new Repository<Dog>());
            dog.Arrange(() => new Dog() { ID = 1 });
            repository.WithParameters(dog).Act((r, d) => r.Add(d));
            repository.WithParameters(dog).Act((r, d) => r.Delete(d));
            repository.Assert.IsTrue(r => r.GetAll().Count == 1);

            test.Execute();
        }
        #endregion
    }
}
