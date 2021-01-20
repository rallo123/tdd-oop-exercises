using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using TestTools.Integrated;
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

        /* Exercise 1A */
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

        [TestMethod("d. Person.FirstName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfNull() {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.FirstName, null));
            person.Assert.Unchanged(p => p.FirstName);

            test.Execute();
        }

        [TestMethod("e. Person.LastName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfNull()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.LastName, null));
            person.Assert.Unchanged(p => p.LastName);

            test.Execute();
        }

        [TestMethod("f. Person.FirstName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOf012345689()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.FirstName, "123456789"));
            person.Assert.Unchanged(p => p.FirstName);

            test.Execute();
        }

        [TestMethod("g. Person.LastName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOf012345689()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.LastName, "123456789"));
            person.Assert.Unchanged(p => p.LastName);

            test.Execute();
        }

        [TestMethod("h. Person.FirstName ignores assigment of string with length 101"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfStringWithLength101()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.FirstName, CreateName(101)));
            person.Assert.Unchanged(p => p.FirstName);

            test.Execute();
        }

        [TestMethod("i. Person.LastName ignores assignment of string with length 101"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfStringWithLength101()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, string>(p => p.LastName, CreateName(101)));
            person.Assert.Unchanged(p => p.LastName);

            test.Execute();
        }

        [TestMethod("j. Person.Age ignores assigment of -1"), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.CreateObject<Person>();

            person.Arrange(() => new Person());
            person.Act(Assignment<Person, int>(p => p.Age, -1));
            person.Assert.Unchanged(p => p.Age);

            test.Execute();
        }

        /* Exercise 1B */
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

        [TestMethod("c. Person.Mother ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void MotherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> child = test.CreateObject<Person>("child");
            UnitTestObject<Person> mother = test.CreateObject<Person>("mother");

            child.Arrange(() => new Person() { Age = 1});
            mother.Arrange(() => new Person() { Age = 0 });
            child.WithParameters(mother).Act(Assignment<Person, Person, Person>(p => p.Mother, p => p));
            child.Assert.Unchanged(p => p.Mother);

            test.Execute();
        }
        
        [TestMethod("d. Person.Father ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void FatherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> child = test.CreateObject<Person>("child");
            UnitTestObject<Person> father = test.CreateObject<Person>("father");

            child.Arrange(() => new Person() { Age = 1 });
            father.Arrange(() => new Person() { Age = 0 });
            child.WithParameters(father).Act(Assignment<Person, Person, Person>(p => p.Father, p => p));
            child.Assert.Unchanged(p => p.Mother);

            test.Execute();
        }

        /* Exercise 1C */
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
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> person = test.CreateAnonymousObject<Person>("person");
            
            generator.Arrange(() => new PersonGenerator());
            person.WithParameters(generator).Arrange(g => g.GeneratePerson());
            
            person.Assert.IsTrue(p => p.FirstName == "Adam");
            person.Assert.IsTrue(p => p.LastName == "Smith");
            person.Assert.IsTrue(p => p.Age == 36);

            test.Execute();
        }

        /* Exercise 1D */
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
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> child = test.CreateAnonymousObject<Person>("child");

            generator.Arrange(() => new PersonGenerator());
            child.WithParameters(generator).Arrange(g => g.GenerateFamily());
            
            child.Assert.IsTrue(p => p.FirstName == "Robin");
            child.Assert.IsTrue(p => p.LastName == "Rich");
            child.Assert.IsTrue(p => p.Age == 10);

            test.Execute();
        }


        [TestMethod("c. PersonGenerator.GenerateFamily generates Waren Rich (36) as father"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsFather()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> father = test.CreateAnonymousObject<Person>("father");
            
            generator.Arrange(() => new PersonGenerator());
            father.WithParameters(generator).Arrange(g => g.GenerateFamily().Father);

            father.Assert.IsTrue(p => p.FirstName == "Warren");
            father.Assert.IsTrue(p => p.LastName == "Rich");
            father.Assert.IsTrue(p => p.Age == 36);

            test.Execute();
        }


        [TestMethod("d. PersonGenerator.GenerateFamily generates Anna Smith (38) as mother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesAnnaRichAsMother()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> mother = test.CreateAnonymousObject<Person>("mother");
            
            generator.Arrange(() => new PersonGenerator());
            mother.WithParameters(generator).Arrange(g => g.GenerateFamily().Mother);

            mother.Assert.IsTrue(p => p.FirstName == "Anna");
            mother.Assert.IsTrue(p => p.LastName == "Smith");
            mother.Assert.IsTrue(p => p.Age == 38);

            test.Execute();
        }


        [TestMethod("e. PersonGenerator.GenerateFamily generates Gustav Rich (66) as grandfather"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesGustavRichAsGrandfather()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> grandFather = test.CreateAnonymousObject<Person>("grandfather");

            generator.Arrange(() => new PersonGenerator());
            grandFather.WithParameters(generator).Arrange(g => g.GenerateFamily().Father.Father);

            grandFather.Assert.IsTrue(p => p.FirstName == "Gustav");
            grandFather.Assert.IsTrue(p => p.LastName == "Rich");
            grandFather.Assert.IsTrue(p => p.Age == 66);

            test.Execute();
        }

        [TestMethod("g. PersonGenerator.GenerateFamily generates Elsa Johnson (65) as grandmother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesElsaJohnsonAsGrandMother()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<PersonGenerator> generator = test.CreateObject<PersonGenerator>("generator");
            AnonymousUnitTestObject<Person> grandMother = test.CreateAnonymousObject<Person>("grandmother");

            generator.Arrange(() => new PersonGenerator());
            grandMother.WithParameters(generator).Arrange(g => g.GenerateFamily().Father.Mother);

            grandMother.Assert.IsTrue(p => p.FirstName == "Elsa");
            grandMother.Assert.IsTrue(p => p.LastName == "Johnson");
            grandMother.Assert.IsTrue(p => p.Age == 65);

            test.Execute();
        }

        /* Exercise 1E */
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
            UnitTestObject<Person> person = test.CreateAnonymousObject<Person>("person");
            UnitTestObject<PersonPrinter> printer = test.CreateAnonymousObject<PersonPrinter>("printer");
            UnitTestConsole console = test.CreateConsole();

            printer.Arrange(() => new PersonPrinter());
            person.Arrange(() => new Person() { FirstName = "Adam", LastName = "Smith", Age = 36 });
            printer.WithParameters(person).Act((p1, p2) => p1.PrintPerson(p2));
            console.Assert.HasWritten("Adam Smith (36)");

            test.Execute();
        }

        /* Exercise 1F */
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
            UnitTestObject<Person> person = test.CreateAnonymousObject<Person>("person");
            UnitTestObject<PersonPrinter> printer = test.CreateAnonymousObject<PersonPrinter>("printer");
            UnitTestConsole console = test.CreateConsole();

            person.Arrange(() => 
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
                }
            );
            printer.WithParameters(person).Act((p1, p2) => p1.PrintFamily(p2));

            console.Assert.HasWritten("Adam Smith (36)\n");
            console.Assert.HasWritten("Robin Rich (10)\n");
            console.Assert.HasWritten("  Warren Rich (36)\n");
            console.Assert.HasWritten("    Gustav Rich (66)\n");
            console.Assert.HasWritten("    Elsa Johnson (65)\n");
            console.Assert.HasWritten("  Anna Smith (38)\n");

            test.Execute();
        }

        /* Exercise 1G */
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
            UnitTestObject<Person> mother = test.CreateObject<Person>();
            UnitTestObject<Person> father = test.CreateObject<Person>();
            UnitTestObject<Person> child = test.CreateObject<Person>();

            mother.Arrange(() => new Person() { Age = 37 });
            father.Arrange(() => new Person() { Age = 37 });
            child.WithParameters(mother, father).Arrange((p1, p2) => new Person(p1, p2));
            child.WithParameters(mother).Assert.IsTrue((p1, p2) => p1.Mother == p2);
            child.WithParameters(father).Assert.IsTrue((p1, p2) => p1.Father == p2);

            test.Execute();
        }

        /* Exercise 1H */
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
            UnitTestObject<Person> person1 = test.CreateObject<Person>();
            UnitTestObject<Person> person2 = test.CreateObject<Person>();

            person1.Arrange(() => new Person());
            person2.Arrange(() => new Person());

            person1.WithParameters(person2).Assert.IsTrue((p1, p2) => p2.ID - p1.ID == 1);

            test.Execute();
        }
    }
}
