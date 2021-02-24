using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
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
            test.AssertPublicProperty<Product, int>(s => s.ID);
            test.Execute();
        }

        [TestMethod("b. Product.Name is a public property")]
        public void ProductTitleIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Product, string>(s => s.Name);
            test.Execute();
        }

        [TestMethod("c. Product.Category is a public property")]
        public void ProductCategoryIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Product, string>(s => s.Category);
            test.Execute();
        }

        [TestMethod("d. Product.Price is a public property")]
        public void StudentAgeIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Product, decimal>(s => s.Price);
            test.Execute();
        }

        [TestMethod("e. Product.Equals equates products with same ID")]
        public void ProductEqualsEquatesProductsWithSameID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(product1, Expr(() => new Product() { ID = 5 }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5 }));
            test.Assert.IsTrue(Expr(product1, product2, (p1, p2) => p1.Equals(p2)));

            test.Execute();
        }

        [TestMethod("f. Product.Equals does not equate products with different ID")]
        public void ProductEqualsDoesNotEquateProductsWithDifferentID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(product1, Expr(() => new Product() { ID = 4 }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5 }));
            test.Assert.IsFalse(Expr(product1, product2, (p1, p2) => p1.Equals(p2)));

            test.Execute();
        }

        [TestMethod("g. Product.GetHashCode equates products with same ID")]
        public void ProductGetHashCodeEquatesProductsWithSameID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(product1, Expr(() => new Product() { ID = 5 }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5 }));
            test.Assert.IsTrue(Expr(product1, product2, (p1, p2) => p1.GetHashCode() == p2.GetHashCode()));

            test.Execute();
        }

        [TestMethod("h. Product.GetHashCode does not equate products with different ID")]
        public void ProductGetHashCodeDoesNotEquateProductsWithDifferentID()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(product1, Expr(() => new Product() { ID = 4 }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5 }));
            test.Assert.IsFalse(Expr(product1, product2, (p1, p2) => p1.GetHashCode() == p2.GetHashCode()));

            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. ProductRepository.Add(Product p) is a public method")]
        public void ProductRepositoryAddIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, Product>((r, p) => r.Add(p));
            test.Execute();
        }

        [TestMethod("b. ProductRepository.Update(Product p) is a public method")]
        public void ProductRepositoryUpdateIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, Product>((r, p) => r.Update(p));
            test.Execute();
        }

        [TestMethod("c. ProductRepository.Delete(Product p) is a public method")]
        public void ProductRepositoryDeleteIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, Product>((r, p) => r.Update(p));
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. ProductRepository implements IEnumerable<T>")]
        public void ProductRepositoryImplementsIEnumerable()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<ProductRepository>(new TypeIsSubclassOfVerifier(typeof(IEnumerable<Product>)));
            test.Execute();
        }

        [TestMethod("b. ProductRepository.Add(Product p) adds product")]
        public void ProductRepositoryAddAddsProduct()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product, Expr(() => new Product()));
            test.Act(Expr(repository, product, (r, p) => r.Add(p)));
            test.Assert.IsTrue(Expr(repository, r => r.Any()));

            test.Execute();
        }

        [TestMethod("c. ProductRepository.Add(Product p) adds product, which cannot be affected")]
        public void ProductRepositoryAddAddsProduct2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product, Expr(() => new Product() { Name = "Name" }));
            test.Act(Expr(repository, product, (r, p) => r.Add(p)));
            test.Act(Expr(product, p => p.SetName("NewName")));
            test.Assert.AreEqual(Expr(repository, r => r.First().Name), Const("Name"));

            test.Execute();
        }

        [TestMethod("d. ProductRepository.Update(Product p) updates product, which cannot be affected")]
        public void ProductRepositoryUpdatesProduct()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product, Expr(() => new Product() { Name = "Name" }));
            test.Act(Expr(repository, product, (r, p) => r.Add(p)));
            test.Act(Expr(product, p => p.SetName("NewName")));
            test.Act(Expr(repository, product, (r, p) => r.Update(p)));
            test.Assert.AreEqual(Expr(repository, r => r.First().Name), Const("NewName"));

            test.Execute();
        }

        [TestMethod("e. ProductRepository.Delete(Product p) removes product again")]
        public void ProductRepositoryDeleteRemovesProductAgain()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product, Expr(() => new Product()));
            test.Act(Expr(repository, product, (r, p) => r.Add(p)));
            test.Act(Expr(repository, product, (r, p) => r.Delete(p)));
            test.Assert.IsTrue(Expr(repository, r => r.Any()));

            test.Execute();
        }
        #endregion

        #region Exercise 3D
        [TestMethod("a. ProductRepository.GetProductByID(int id) is a public method")]
        public void ProductRepositoryGetProductByIDIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, int, Product>((r, i) => r.GetProductByID(i));
            test.Execute();
        }

        [TestMethod("b. ProductRepository.GetLeastExpensiveProduct() is a public method")]
        public void ProductRepositoryGetLeastExpensiveProductIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, Product>(r => r.GetLeastExpensiveProduct());
            test.Execute();
        }

        [TestMethod("c. ProductRepository.GetMostExpensiveProduct() is a public method")]
        public void ProductRepositoryGetMostExpensiveProductIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, Product>(r => r.GetMostExpensiveProduct());
            test.Execute();
        }

        [TestMethod("d. ProductRepository.GetAverageProductPrice() is a public method")]
        public void ProductRepositoryGetAverageProductPriceIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, decimal>(r => r.GetAverageProductPrice());
            test.Execute();
        }

        [TestMethod("e. ProductRepository.GetProductsInCategory(string category) is a public method")]
        public void ProductRepositoryGetProductsInCategoryIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, string, IEnumerable<Product>>((r, s) => r.GetProductsInCategory(s));
            test.Execute();
        }

        [TestMethod("f. ProductRepository.GetProductCategories() is a public method")]
        public void ProductRepositoryGetProductCategoriesIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<ProductRepository, IEnumerable<string>>(r => r.GetProductCategories());
            test.Execute();
        }

        [TestMethod("g. ProductRepository.GetProductByID(int id) returns correctly")]
        public void ProductRepositoryGetProductByIDReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product, Expr(() => new Product() { ID = 5 }));
            test.Act(Expr(repository, product, (r, p) => r.Add(p)));
            test.Assert.AreEqual(Expr(repository, r => r.GetProductByID(5)), Expr(product, p => p));

            test.Execute();
        }

        [TestMethod("h. ProductRepository.GetLeastExpensiveProduct() returns correctly")]
        public void ProductRepositoryGetLeastExpensiveProductReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> leastExpensiveProduct = test.CreateVariable<Product>();
            TestVariable<Product> mostExpensiveProduct = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(leastExpensiveProduct, Expr(() => new Product() { ID = 4, Price = 10M }));
            test.Arrange(mostExpensiveProduct, Expr(() => new Product() { ID = 5, Price = 20M }));
            test.Act(Expr(repository, leastExpensiveProduct, (r, p) => r.Add(p)));
            test.Act(Expr(repository, mostExpensiveProduct, (r, p) => r.Add(p)));
            test.Assert.AreEqual(Expr(repository, r => r.GetLeastExpensiveProduct()), Expr(leastExpensiveProduct, p => p));

            test.Execute();
        }

        [TestMethod("i. ProductRepository.GetMostExpensiveProduct() returns correctly")]
        public void ProductRepositoryGetMostExpensiveProductReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> leastExpensiveProduct = test.CreateVariable<Product>();
            TestVariable<Product> mostExpensiveProduct = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(leastExpensiveProduct, Expr(() => new Product() { ID = 4, Price = 10M }));
            test.Arrange(mostExpensiveProduct, Expr(() => new Product() { ID = 5, Price = 20M }));
            test.Act(Expr(repository, leastExpensiveProduct, (r, p) => r.Add(p)));
            test.Act(Expr(repository, mostExpensiveProduct, (r, p) => r.Add(p)));
            test.Assert.AreEqual(Expr(repository, r => r.GetMostExpensiveProduct()), Expr(mostExpensiveProduct, p => p));

            test.Execute();
        }

        [TestMethod("i. ProductRepository.GetAverageProductPrice() returns correctly")]
        public void ProductRepositoryGetAverageProductPriceReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product1, Expr(() => new Product() { ID = 4, Price = 10M }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5, Price = 20M }));
            test.Act(Expr(repository, product1, (r, p) => r.Add(p)));
            test.Act(Expr(repository, product2, (r, p) => r.Add(p)));
            test.Assert.AreEqual(Expr(repository, r => r.GetAverageProductPrice()), Const(15M));

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

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product1, Expr(() => new Product() { ID = 4, Category = "Food" }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5, Category = "Food" }));
            test.Arrange(product3, Expr(() => new Product() { ID = 6, Category = "Electronics" }));
            test.Act(Expr(repository, product1, (r, p) => r.Add(p)));
            test.Act(Expr(repository, product2, (r, p) => r.Add(p)));
            test.Act(Expr(repository, product3, (r, p) => r.Add(p)));
            test.Assert.IsTrue(Expr(repository, product1, product2, (r, p1, p2) => r.GetProductsInCategory("Food").SequenceEqual(new[] { p1, p2 })));

            test.Execute();
        }

        [TestMethod("k. ProductRepository.GetProductCategories() returns correctly")]
        public void ProductRepositoryGetProductCategoriesReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<ProductRepository> repository = test.CreateVariable<ProductRepository>();
            TestVariable<Product> product1 = test.CreateVariable<Product>();
            TestVariable<Product> product2 = test.CreateVariable<Product>();

            test.Arrange(repository, Expr(() => new ProductRepository()));
            test.Arrange(product1, Expr(() => new Product() { ID = 4, Category = "Food" }));
            test.Arrange(product2, Expr(() => new Product() { ID = 5, Category = "Electronics" }));
            test.Act(Expr(repository, product1, (r, p) => r.Add(p)));
            test.Act(Expr(repository, product2, (r, p) => r.Add(p)));
            test.Assert.IsTrue(Expr(repository, product1, product2, (r, p1, p2) => r.GetProductCategories().SequenceEqual(new[] { "Food", "Electronics" })));

            test.Execute();
        }
        #endregion    
    }
}
