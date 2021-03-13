using Lecture_7_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_7_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_7_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4A
        [TestMethod("a. Repository has a default constructor"), TestCategory("4A")]
        public void RepositoryHasPublicDefaultConstructor()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<Repository<ICloneable>>(() => new Repository<ICloneable>());
            test.Execute();
        }

        [TestMethod("b. Repository has a constructor that takes ILogger"), TestCategory("4A")]
        public void RepositoryHasPublicDefaultConstructorThatTakesILogger()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<ILogger, Repository<ICloneable>>(l => new Repository<ICloneable>(l));
            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("a. Repository.Add() takes TEntity and adds it to list of entities"), TestCategory("4B")]
        public void RepositoryAddTakesTEntityAndAddsToEntities()
        {
            Repository<Dog> repository = new Repository<Dog>();
            
            repository.Add(new Dog());

            Assert.AreEqual(repository.GetAll().Count, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Repository<Dog>> _repository = test.CreateVariable<Repository<Dog>>();
            test.Arrange(_repository, Expr(() => new Repository<Dog>()));
            test.Act(Expr(_repository, r => r.Add(new Dog())));
            test.Assert.AreEqual(Expr(_repository, r => r.GetAll().Count), Const(1));
            test.Execute();
        }
        #endregion

        #region Exercise 4C
        [TestMethod("a. Repository.GetAll() takes nothing and returns list of all entities"), TestCategory("4C")]
        public void RepositoryGetAllReturnsListOfEntities()
        {
            Repository<Dog> repository = new Repository<Dog>();

            repository.Add(new Dog());
            repository.Add(new Dog());

            Assert.AreEqual(repository.GetAll().Count, 2);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Repository<Dog>> _repository = test.CreateVariable<Repository<Dog>>();
            test.Arrange(_repository, Expr(() => new Repository<Dog>()));
            test.Act(Expr(_repository, r => r.Add(new Dog())));
            test.Act(Expr(_repository, r => r.Add(new Dog())));
            test.Assert.AreEqual(Expr(_repository, r => r.GetAll().Count), Const(2));
            test.Execute();
        }
        #endregion

        #region Exercise 4D
        [TestMethod("a. Repository.Update(TEntity) updates an entity"), TestCategory("4d")]
        public void RepositoryUpdateUpdatesAnEntity()
        {
            Repository<Dog> repository = new Repository<Dog>();
            Dog dog = new Dog() 
            {
                ID = 2, 
                Name = "Name"
            };

            repository.Add(dog);
            dog.Name = "NewName";
            repository.Update(dog);

            Assert.AreEqual(repository.GetAll().First().Name, "NewName");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Repository<Dog>> _repository = test.CreateVariable<Repository<Dog>>();
            TestVariable<Dog> _dog = test.CreateVariable<Dog>();
            test.Arrange(_repository, Expr(() => new Repository<Dog>()));
            test.Arrange(_dog, Expr(() => new Dog() { ID = 2, Name = "Name" }));
            test.Act(Expr(_repository, _dog, (r, d) => r.Add(d)));
            test.Act(Expr(_dog, d => d.SetName("NewName")));
            test.Act(Expr(_repository, _dog, (r, d) => r.Update(d)));
            test.Assert.AreEqual(Expr(_repository, r => r.GetAll().First().Name), Const("NewName"));
            test.Execute();
        }
        #endregion

        #region Exercise 4e
        [TestMethod("Repository.Delete(TEntity) Deletes an entity"), TestCategory("4e")]
        public void RepositoryDeleteDeletesAnEntity()
        {
            Repository<Dog> repository = new Repository<Dog>();
            Dog dog = new Dog() { ID = 1 };

            repository.Add(dog);
            repository.Delete(dog);

            Assert.AreEqual(repository.GetAll().Count, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Repository<Dog>> _repository = test.CreateVariable<Repository<Dog>>();
            TestVariable<Dog> _dog = test.CreateVariable<Dog>();
            test.Arrange(_repository, Expr(() => new Repository<Dog>()));
            test.Arrange(_dog, Expr(() => new Dog() { ID = 1 }));
            test.Act(Expr(_repository, _dog, (r, d) => r.Add(d)));
            test.Act(Expr(_repository, _dog, (r, d) => r.Delete(d)));
            test.Assert.AreEqual(Expr(_repository, r => r.GetAll().Count), Const(0));
            test.Execute();
        }
        #endregion
    }
}
