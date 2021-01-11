using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Integrated
{
    public class StructureTest
    {
        internal StructureTest() { }

        #region Constructor Assertions
        public void AssertConstructorSignatureMatchesDual<T1>(Expression<Func<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructorPrivate<T1>(Expression<Func<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructorProtected<T1>(Expression<Func<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public void AssertConstructorPublic<T1>(Expression<Func<T1>> expression)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Field Assertion
        public void AssertField<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertFieldType<T1, T2>(Expression<Func<T1, T2>> expression, Type type)
        {
            throw new NotImplementedException();
        }

        public void AssertFieldTypeMatchesDual<T1, T2>(Expression<Func<T1, T2>> expression, Type type)
        {
            throw new NotImplementedException();
        }

        public  void AssertPrivateField<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertProtectedField<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPublicField<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method Assertions
        public void AssertMethod<T1>(Expression<Action<T1>> expression)
        {

        }

        public  void AssertMethod<T1, T2>(Expression<Func<T1, T2>> expression)
        {

        }

        public void AssertPrivateMethod<T1>(Expression<Action<T1>> expression)
        {

        }

        public  void AssertPrivateMethod<T1, T2>(Expression<Func<T1 , T2>> expression)
        {

        }

        public void AssertProtectedMethod<T1>(Expression<Action<T1>> expression)
        {

        }

        public  void AssertProtectedMethod<T1, T2>(Expression<Func<T1 , T2>> expression)
        {

        }

        public void AssertPublicMethod<T1>(Expression<Action<T1>> expression)
        {

        }

        public  void AssertPublicMethod<T1, T2>(Expression<Func<T1 , T2>> expression)
        {

        }

        public void AssertMethodSignatureMatchesDual<T1>(Expression<Action<T1>> expression)
        {
            throw new NotImplementedException();
        }

        public void AssertMethodSignatureMatchesDual<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Property Assertions
        public  void AssertProperty<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertReadOnlyProperty<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertWriteOnlyProperty<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertyType<T1, T2>(Expression<Func<T1 , T2>> expression, Type propertyType)
        {

        }

        public void AssertPropertyTypeMatchesDual<T1, T2>(Expression<Func<T1, T2>> expression)
        {

        }

        public  void AssertPropertyGetterPrivate<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertyGetterProtected<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertyGetterPublic<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertySetterPrivate<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertySetterProtected<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertySetterPublic<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            throw new NotImplementedException();
        }

        public  void AssertPropertyGetterAndSetterPrivate<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            AssertPropertyGetterPrivate(expression);
            AssertPropertySetterPrivate(expression);
        }

        public  void AssertPropertyGetterAndSetterProtected<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            AssertPropertyGetterProtected(expression);
            AssertPropertySetterProtected(expression);
        }

        public  void AssertPropertyGetterAndSetterPublic<T1, T2>(Expression<Func<T1 , T2>> expression)
        {
            AssertPropertyGetterPublic(expression);
            AssertPropertySetterPublic(expression);
        }
        #endregion
    }
}
