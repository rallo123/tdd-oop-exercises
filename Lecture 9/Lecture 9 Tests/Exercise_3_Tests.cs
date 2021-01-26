using Lecture_9_Solutions;
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
using static Lecture_9_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_9_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        #region Exercise 3A
        [TestMethod("a. Product.ID is a public property")]
        public void ProductIDISAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Product, int>(s => s.ID, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Product.Name is a public property")]
        public void ProductTitleIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Product, string>(s => s.Name, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Product.Category is a public property")]
        public void ProductCategoryIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Product, string>(s => s.Category, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. Product.Price is a public property")]
        public void StudentAgeIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Product, decimal>(s => s.Price, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("e. Product.Equals equates products with same ID")]
        public void ProductEqualsEquatesProductsWithSameID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            product1.Arrange(() => new Product() { ID = 5 });
            product2.Arrange(() => new Product() { ID = 5 });
            product1.WithParameters(product2).Assert.IsTrue((p1, p2) => p1.Equals(p2));

            test.Execute();
        }

        [TestMethod("f. Product.Equals does not equate products with different ID")]
        public void ProductEqualsDoesNotEquateProductsWithDifferentID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            product1.Arrange(() => new Product() { ID = 4 });
            product2.Arrange(() => new Product() { ID = 5 });
            product1.WithParameters(product2).Assert.IsFalse((p1, p2) => p1.Equals(p2));

            test.Execute();
        }

        [TestMethod("g. Product.GetHashCode equates products with same ID")]
        public void ProductGetHashCodeEquatesProductsWithSameID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            product1.Arrange(() => new Product() { ID = 5 });
            product2.Arrange(() => new Product() { ID = 5 });
            product1.WithParameters(product2).Assert.IsTrue((p1, p2) => p1.GetHashCode() == p2.GetHashCode());

            test.Execute();
        }

        [TestMethod("h. Product.GetHashCode does not equate products with different ID")]
        public void ProductGetHashCodeDoesNotEquateProductsWithDifferentID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            product1.Arrange(() => new Product() { ID = 4 });
            product2.Arrange(() => new Product() { ID = 5 });
            product1.WithParameters(product2).Assert.IsFalse((p1, p2) => p1.GetHashCode() == p2.GetHashCode());

            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. ProductRepository.Add(Product p) is a public method")]
        public void ProductRepositoryAddIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, Product>((r, p) => r.Add(p), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. ProductRepository.Update(Product p) is a public method")]
        public void ProductRepositoryUpdateIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, Product>((r, p) => r.Update(p), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. ProductRepository.Delete(Product p) is a public method")]
        public void ProductRepositoryDeleteIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, Product>((r, p) => r.Update(p), IsPublicMethod);
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. ProductRepository implements IEnumerable<T>")]
        public void ProductRepositoryImplementsIEnumerable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<ProductRepository>(HasClassImplementedInterface(typeof(IEnumerable<Product>)));
            test.Execute();
        }

        [TestMethod("b. ProductRepository.Add(Product p) adds product")]
        public void ProductRepositoryAddAddsProduct()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product.Arrange(() => new Product());
            repository.WithParameters(product).Act((r, p) => r.Add(p));
            repository.WithParameters(product).Assert.IsTrue((r, p) => r.SequenceEqual(new[] { p }));

            test.Execute();
        }

        [TestMethod("c. ProductRepository.Add(Product p) adds product, which cannot be affected")]
        public void ProductRepositoryAddAddsProduct2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product.Arrange(() => new Product() { Name = "Name" });
            repository.WithParameters(product).Act((r, p) => r.Add(p));
            product.Act(Assignment<Product, string>(p => p.Name, "NewName"));
            repository.Assert.IsTrue(r => r.First().Name == "Name");

            test.Execute();
        }

        [TestMethod("d. ProductRepository.Update(Product p) updates product, which cannot be affected")]
        public void ProductRepositoryUpdatesProduct()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product.Arrange(() => new Product() { Name = "Name" });
            repository.WithParameters(product).Act((r, p) => r.Add(p));
            product.Act(Assignment<Product, string>(p => p.Name, "Name"));
            repository.WithParameters(product).Act((r, p) => r.Update(p));
            repository.Assert.IsTrue(r => r.First().Name == "NewName");

            test.Execute();
        }

        [TestMethod("e. ProductRepository.Delete(Product p) removes product again")]
        public void ProductRepositoryDeleteRemovesProductAgain()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product.Arrange(() => new Product() { Name = "Name" });
            repository.WithParameters(product).Act((r, p) => r.Add(p));
            repository.WithParameters(product).Act((r, p) => r.Delete(p));
            repository.Assert.IsFalse(r => r.Any());

            test.Execute();
        }
        #endregion

        #region Exercise 3D
        [TestMethod("a. ProductRepository.GetProductByID(int id) is a public method")]
        public void ProductRepositoryGetProductByIDIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, int, Product>((r, i) => r.GetProductByID(i), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. ProductRepository.GetLeastExpensiveProduct() is a public method")]
        public void ProductRepositoryGetLeastExpensiveProductIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, Product>(r => r.GetLeastExpensiveProduct(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. ProductRepository.GetMostExpensiveProduct() is a public method")]
        public void ProductRepositoryGetMostExpensiveProductIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, Product>(r => r.GetMostExpensiveProduct(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. ProductRepository.GetAverageProductPrice() is a public method")]
        public void ProductRepositoryGetAverageProductPriceIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, decimal>(r => r.GetAverageProductPrice(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("e. ProductRepository.GetProductsInCategory(string category) is a public method")]
        public void ProductRepositoryGetProductsInCategoryIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, string, IEnumerable<Product>>((r, s) => r.GetProductsInCategory(s), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("f. ProductRepository.GetProductCategories() is a public method")]
        public void ProductRepositoryGetProductCategoriesIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<ProductRepository, IEnumerable<string>>(r => r.GetProductCategories(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("g. ProductRepository.GetProductByID(int id) returns correctly")]
        public void ProductRepositoryGetProductByIDReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product.Arrange(() => new Product() { ID = 5 });
            repository.WithParameters(product).Act((r, p) => r.Add(p));
            repository.WithParameters(product).Assert.IsTrue((r, p) => r.GetProductByID(5) == p);

            test.Execute();
        }

        [TestMethod("h. ProductRepository.GetLeastExpensiveProduct() returns correctly")]
        public void ProductRepositoryGetLeastExpensiveProductReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> leastExpensiveProduct = test.CreateVariable<Product>();
            TestVariable<Product> mostExpensiveProduct = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            leastExpensiveProduct.Arrange(() => new Product() { ID = 4, Price = 10M });
            mostExpensiveProduct.Arrange(() => new Product() { ID = 5, Price = 20M });
            repository.WithParameters(leastExpensiveProduct).Act((r, p) => r.Add(p));
            repository.WithParameters(mostExpensiveProduct).Act((r, p) => r.Add(p));
            repository.WithParameters(leastExpensiveProduct).Assert.IsTrue((r, p) => r.GetLeastExpensiveProduct() == p);

            test.Execute();
        }

        [TestMethod("i. ProductRepository.GetMostExpensiveProduct() returns correctly")]
        public void ProductRepositoryGetMostExpensiveProductReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> leastExpensiveProduct = test.CreateVariable<Product>();
            TestVariable<Product> mostExpensiveProduct = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            leastExpensiveProduct.Arrange(() => new Product() { ID = 4, Price = 10M });
            mostExpensiveProduct.Arrange(() => new Product() { ID = 5, Price = 20M });
            repository.WithParameters(leastExpensiveProduct).Act((r, p) => r.Add(p));
            repository.WithParameters(mostExpensiveProduct).Act((r, p) => r.Add(p));
            repository.WithParameters(mostExpensiveProduct).Assert.IsTrue((r, p) => r.GetMostExpensiveProduct() == p);

            test.Execute();
        }

        [TestMethod("i. ProductRepository.GetAverageProductPrice() returns correctly")]
        public void ProductRepositoryGetAverageProductPriceReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product1.Arrange(() => new Product() { ID = 4, Price = 10M });
            product2.Arrange(() => new Product() { ID = 5, Price = 20M });
            repository.WithParameters(product1).Act((r, p) => r.Add(p));
            repository.WithParameters(product2).Act((r, p) => r.Add(p));
            repository.Assert.IsTrue(r => r.GetAverageProductPrice() == 15M);

            test.Execute();
        }

        [TestMethod("j. ProductRepository.GetProductsInCategory(string category) returns correctly")]
        public void ProductRepositoryGetProductsInCategoryReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();
            TestVariable<Product> product3 = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product1.Arrange(() => new Product() { ID = 4, Category = "Food" });
            product2.Arrange(() => new Product() { ID = 5, Category = "Food" });
            product3.Arrange(() => new Product() { ID = 6, Category = "Electronics" });
            repository.WithParameters(product1).Act((r, p) => r.Add(p));
            repository.WithParameters(product2).Act((r, p) => r.Add(p));
            repository.WithParameters(product3).Act((r, p) => r.Add(p));
            repository.WithParameters(product1, product2).Assert.IsTrue((r, p1, p2) => r.GetProductsInCategory("Food").SequenceEqual(new[] { p1, p2 }));

            test.Execute();
        }

        [TestMethod("k. ProductRepository.GetProductCategories() returns correctly")]
        public void ProductRepositoryGetProductCategoriesReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            repository.Arrange(() => new ProductRepository());
            product1.Arrange(() => new Product() { ID = 4, Category = "Food" });
            product2.Arrange(() => new Product() { ID = 6, Category = "Electronics" });
            repository.WithParameters(product1).Act((r, p) => r.Add(p));
            repository.WithParameters(product2).Act((r, p) => r.Add(p));
            repository.WithParameters(product1, product2).Assert.IsTrue((r, p1, p2) => r.GetProductCategories().SequenceEqual(new[] { "Food", "Electronics" }));

            test.Execute();
        }
        #endregion    
    }
}
