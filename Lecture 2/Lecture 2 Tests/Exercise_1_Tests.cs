using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Helpers.ExpressionHelper;
using static TestTools.Helpers.StructureHelper;
using static Lecture_2_Tests.TestHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        private string CreateName(int length)
        {
            throw new NotImplementedException();
        }

        #region Exercise 1A
        [TestMethod("a. Person.FirstName is public string property"), TestCategory("Exercise 1A")]
        public void FirstNameIsPublicStringProperty() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, string>(p => p.FirstName, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Person.LastName is public string property"), TestCategory("Exercise 1A")]
        public void LastNameIsPublicStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, string>(p => p.LastName, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Person.Age is public int property"), TestCategory("Exercise 1A")]
        public void AgeIsPublicIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, int>(p => p.Age, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. Person.FirstName is initialized as \"Unknown\""), TestCategory("Exercise 1A")]
        public void FirstNameIsInitializedAsUnnamed()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>();

            test.Arrange(person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(person, p => p.FirstName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("e. Person.FirstName is initialized as \"Unknown\""), TestCategory("Exercise 1A")]
        public void LastNameIsInitializedAsUnnamed()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(person, p => p.LastName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("f. Person.FirstName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfNull() {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.FirstName), Const<string>(null));
            test.Assert.AreEqual(Expr(person, p => p.FirstName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("g. Person.LastName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfNull()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.LastName), Const<string>(null));
            test.Assert.AreEqual(Expr(person, p => p.LastName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("h. Person.FirstName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOf012345689()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.FirstName), Const("123456789"));
            test.Assert.AreEqual(Expr(person, p => p.FirstName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("i. Person.LastName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOf012345689()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.LastName), Const("123456789"));
            test.Assert.AreEqual(Expr(person, p => p.LastName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("j. Person.FirstName ignores assigment of string with length 101"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfStringWithLength101()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.FirstName), Const(CreateName(101)));
            test.Assert.AreEqual(Expr(person, p => p.FirstName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("k. Person.LastName ignores assignment of string with length 101"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfStringWithLength101()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.LastName), Const(CreateName(101)));
            test.Assert.AreEqual(Expr(person, p => p.LastName), Const("Unknown"));

            test.Execute();
        }

        [TestMethod("l. Person.Age is initialized as 0"), TestCategory("Exercise 1A")]
        public void AgeIsInitilizedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(person, p => p.Age), Const(0));

            test.Execute();
        }

        [TestMethod("m. Person.Age ignores assigment of -1"), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assign(Expr(person, p => p.Age), Const(-1));
            test.Assert.AreEqual(Expr(person, p => p.Age), Const(-1));

            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("a. Person.Mother is public Person property"), TestCategory("Exercise 1B")]
        public void MotherIsPublicPersonProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, Person>(p => p.Mother, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Person.Father is public Person property"), TestCategory("Exercise 1B")]
        public void FatherIsPublicPersonProperty() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, Person>(p => p.Father, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Person.Mother is initialized as null"), TestCategory("Exercise 1A")]
        public void MotherIsInitilizedAsnull()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assert.IsNull(Expr(person, p => p.Mother));

            test.Execute();
        }

        [TestMethod("d. Person.Father is initialized as null"), TestCategory("Exercise 1A")]
        public void FatherIsInitilizedAsnull()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person()));
            test.Assert.IsNull(Expr(person, p => p.Mother));

            test.Execute();
        }

        [TestMethod("c. Person.Mother ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void MotherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> child = test.CreateVariable<Person>(nameof(child));
            TestVariable<Person> mother = test.CreateVariable<Person>(nameof(mother));

            test.Arrange(child, Expr(() => new Person() { Age = 1 }));
            test.Arrange(mother, Expr(() => new Person() { Age = 0 }));
            test.Assign(Expr(child, p => p.Mother), Expr(mother, p => p));
            test.Assert.IsNull(Expr(mother, p => p.Mother));

            test.Execute();
        }
        
        [TestMethod("d. Person.Father ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void FatherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> child = test.CreateVariable<Person>(nameof(child));
            TestVariable<Person> father = test.CreateVariable<Person>(nameof(father));

            test.Arrange(child, Expr(() => new Person() { Age = 1 }));
            test.Arrange(father, Expr(() => new Person() { Age = 0 }));
            test.Assign(Expr(child, p => p.Father), Expr(father, p => p));
            test.Assert.IsNull(Expr(father, p => p.Father));

            test.Execute();
        }
        #endregion

        #region Exercise 1C
        [TestMethod("a. PersonGenerator.GeneratePerson takes no arguments and returns Person"), TestCategory("Exercise 1C")]
        public void GeneratePersonReturnsPerson()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<PersonGenerator, Person>(g => g.GeneratePerson(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. PersonGenerator.GeneratePerson generates Adam Smith (36)"), TestCategory("Exercise 1C")]
        public void GeneratePersonCreatesAdamSmith()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(person, Expr(generator, g => g.GeneratePerson()));
            test.Assert.AreEqual(Expr(person, p => p.FirstName), Const("Adam"));
            test.Assert.AreEqual(Expr(person, p => p.LastName), Const("Smith"));
            test.Assert.AreEqual(Expr(person, p => p.Age), Const(36));

            test.Execute();
        }
        #endregion

        #region Exercise 1D
        [TestMethod("a. PersonGenerator.GenerateFamily takes no arguments and returns Person "), TestCategory("Exercise 1D")]
        public void GenerateFamilyReturnsPerson()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<PersonGenerator, Person>(g => g.GenerateFamily(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. PersonGenerator.GenerateFamily generates Robin Rich (10) as child"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsChild()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> child = test.CreateVariable<Person>(nameof(child));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(child, Expr(generator, g => g.GenerateFamily()));
            test.Assert.AreEqual(Expr(child, p => p.FirstName), Const("Robin"));
            test.Assert.AreEqual(Expr(child, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(child, p => p.Age), Const(10));

            test.Execute();
        }

        [TestMethod("c. PersonGenerator.GenerateFamily generates Waren Rich (36) as father"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsFather()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> father = test.CreateVariable<Person>(nameof(father));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(father, Expr(generator, g => g.GenerateFamily().Father));
            test.Assert.AreEqual(Expr(father, p => p.FirstName), Const("Warren"));
            test.Assert.AreEqual(Expr(father, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(father, p => p.Age), Const(36));

            test.Execute();
        }

        [TestMethod("d. PersonGenerator.GenerateFamily generates Anna Smith (38) as mother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesAnnaRichAsMother()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> mother = test.CreateVariable<Person>(nameof(mother));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(mother, Expr(generator, g => g.GenerateFamily().Mother));
            test.Assert.AreEqual(Expr(mother, p => p.FirstName), Const("Anna"));
            test.Assert.AreEqual(Expr(mother, p => p.LastName), Const("Smith"));
            test.Assert.AreEqual(Expr(mother, p => p.Age), Const(38));

            test.Execute();
        }

        [TestMethod("e. PersonGenerator.GenerateFamily generates Gustav Rich (66) as grandfather"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesGustavRichAsGrandfather()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> grandFather = test.CreateVariable<Person>(nameof(grandFather));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(grandFather, Expr(generator, g => g.GenerateFamily().Father.Father));
            test.Assert.AreEqual(Expr(grandFather, p => p.FirstName), Const("Gustav"));
            test.Assert.AreEqual(Expr(grandFather, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(grandFather, p => p.Age), Const(66));

            test.Execute();
        }

        [TestMethod("f. PersonGenerator.GenerateFamily generates Elsa Johnson (65) as grandmother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesElsaJohnsonAsGrandMother()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> generator = test.CreateVariable<PersonGenerator>(nameof(generator));
            TestVariable<Person> grandMother = test.CreateVariable<Person>(nameof(grandMother));

            test.Arrange(generator, Expr(() => new PersonGenerator()));
            test.Arrange(grandMother, Expr(generator, g => g.GenerateFamily().Father.Mother));
            test.Assert.AreEqual(Expr(grandMother, p => p.FirstName), Const("Elsa"));
            test.Assert.AreEqual(Expr(grandMother, p => p.LastName), Const("Johnson"));
            test.Assert.AreEqual(Expr(grandMother, p => p.Age), Const(65));

            test.Execute();
        }
        #endregion

        #region Exercise 1E
        [TestMethod("a. PersonPrinter.PrintPerson takes person as argument and returns nothing"), TestCategory("Exercise 1E")]
        public void PrintPersonTakesPersonAsArgumentAndReturnsNothing() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<PersonPrinter, Person>((p1, p2) => p1.PrintPerson(p2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. PersonPrinter.PrintPrints prints correctly"), TestCategory("Exercise 1E")]
        public void PrintPersonPrintsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));
            TestVariable<PersonPrinter> printer = test.CreateVariable<PersonPrinter>(nameof(printer));
            TestConsole console = test.CaptureConsole();

            test.Arrange(person, Expr(() => new Person() { FirstName = "Adam", LastName = "Smith", Age = 36 }));
            test.Arrange(printer, Expr(() => new PersonPrinter()));
            test.Act(Expr(printer, person, (p1, p2) => p1.PrintPerson(p2)));
            console.Assert.HasWritten("Adam Smith (36)");

            test.Execute();
        }
        #endregion

        #region Exercise 1F
        [TestMethod("a. PersonPrinter.PrintFamily takes person as argument and returns nothing"), TestCategory("Exercise 1F")]
        public void PrintFamilyTakesPersonAsArgumentAndReturnsNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<PersonPrinter, Person>((p1, p2) => p1.PrintFamily(p2), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. PersonPrinter.PrintFamily prints correctly"), TestCategory("Exercise 1F")]
        public void PrintFamilyPrintsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>("person");
            TestVariable<PersonPrinter> printer = test.CreateVariable<PersonPrinter>("printer");
            TestConsole console = test.CaptureConsole();

            test.Arrange(person, Expr(() => 
                new Person() { 
                    FirstName = "Warren",
                    LastName = "Rich", 
                    Age = 36, 
                    Mother = new Person() { 
                        FirstName = "Warren", 
                        LastName = "Rich", 
                        Age = 36 
                    },
                    Father = new Person() { 
                        FirstName = "Warren", 
                        LastName = "Rich", 
                        Age = 36, 
                        Mother = new Person() { 
                            FirstName = "Elsa", 
                            LastName = "Johnson", 
                            Age = 65 
                        }, 
                        Father = new Person() { 
                            FirstName = "Gustav",
                            LastName = "Rich", 
                            Age = 66 
                        } 
                    }
                })
            );
            test.Act(Expr(printer, person, (p1, p2) => p1.PrintFamily(p2)));

            console.Assert.HasWritten("Adam Smith (36)\n");
            console.Assert.HasWritten("Robin Rich (10)\n");
            console.Assert.HasWritten("  Warren Rich (36)\n");
            console.Assert.HasWritten("    Gustav Rich (66)\n");
            console.Assert.HasWritten("    Elsa Johnson (65)\n");
            console.Assert.HasWritten("  Anna Smith (38)\n");

            test.Execute();
        }
        #endregion

        #region Exercise 1G
        [TestMethod("a. Person has constructor which takes no arguments"), TestCategory("Exercise 1G")]
        public void PersonHasConstructorWhichTakesNoArguments()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Person>(() => new Person(), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("b. Person has constructor which two persons as arguments"), TestCategory("Exercise 1G")]
        public void PersonHasconstructorWhichTakesTwoPersonsAsArguments()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Person, Person, Person>((p1, p2) => new Person(p1, p2), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("c. Person constructor with 2 persons as arguments sets mother and father property"), TestCategory("Exercise 1G")]
        public void PersonConstructorWithTwoPersonArgumentsSetsMotherAndFatherProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> mother = test.CreateVariable<Person>();
            TestVariable<Person> father = test.CreateVariable<Person>();
            TestVariable<Person> child = test.CreateVariable<Person>();

            test.Arrange(mother, Expr(() => new Person() { Age = 37 }));
            test.Arrange(father, Expr(() => new Person() { Age = 37 }));
            test.Arrange(child, Expr(mother, father, (p1, p2) => new Person(p1, p2)));
            test.Assert.AreSame(Expr(child, p => p.Mother), Expr(mother, p => p));
            test.Assert.AreSame(Expr(child, p => p.Father), Expr(father, p => p));

            test.Execute();
        }
        #endregion

        #region Exercise 1H
        [TestMethod("a. Person.ID is public read-only int property"), TestCategory("Exercise 1H")]
        public void IDIsPublicReadonlyIntProperty() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, int>(p => p.ID, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Person.ID increases by 1 for each new person"), TestCategory("Exercise 1H")]
        public void IDIncreasesByOneForEachNewPerson()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person1 = test.CreateVariable<Person>(nameof(person1));
            TestVariable<Person> person2 = test.CreateVariable<Person>(nameof(person2));

            test.Arrange(person1, Expr(() => new Person()));
            test.Arrange(person2, Expr(() => new Person()));
            test.Assert.IsTrue(Expr(person1, person2, (p1, p2) => p1.ID + 1 == p2.ID));

            test.Execute();
        }
        #endregion
    }
}
