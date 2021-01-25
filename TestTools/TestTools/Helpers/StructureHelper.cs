using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Helpers
{
    public static class StructureHelper
    {
        #region Class Predicates 
        public static Expression<Func<Type, bool>> IsGenericClass
        {
            get { return t => t.IsGenericType; }
        }

        public static Expression<Func<Type, bool>> IsStaticClass
        {
            get { return t => t.IsAbstract && t.IsSealed; }
        }

        public static Expression<Func<Type, bool>> HasClassImplementedInterface(Type @interface)
        {
            return t => t.IsAssignableFrom(@interface);
        }
        #endregion

        #region Constructor Predicates
        public static Expression<Func<ConstructorInfo, bool>> IsPublicConstructor
        {
            get { return info => info.IsPublic; }
        }

        public static Expression<Func<ConstructorInfo, bool>> IsGenericConstructor
        {
            get { return info => info.IsGenericMethod; }
        }
        #endregion

        #region Delegate Predicate 
        public static Expression<Func<Type, bool>> IsPublicDelegate
        {
            get { return t => t.IsPublic; }
        }
        #endregion

        #region Event Predicates
        public static Expression<Func<EventInfo, bool>> IsPublicEvent
        {
            get { return info => info.AddMethod.IsPublic && info.RemoveMethod.IsPublic; }
        }
        #endregion

        #region Other Event Methods
        public static EventInfo GetEventInfo<TInstance>(string name)
        {
            return typeof(TInstance).GetEvent(name);
        }
        #endregion

        #region Field Predicates 
        public static Expression<Func<FieldInfo, bool>> IsPublicField
        {
            get { return info => info.IsPublic; }
        }

        public static Expression<Func<FieldInfo, bool>> IsPublicReadOnlyField
        {
            get { return info => info.IsInitOnly; }
        }
        #endregion

        #region Property Predicates
        public static Expression<Func<PropertyInfo, bool>> IsPublicProperty
        {
            get { return info => info.GetMethod.IsPublic && info.SetMethod.IsPublic; }
        }

        public static Expression<Func<PropertyInfo, bool>> IsPublicReadonlyProperty
        {
            get { return info => info.GetMethod.IsPublic && (!info.CanWrite || !info.SetMethod.IsPublic); }
        }

        public static Expression<Func<PropertyInfo, bool>> IsGenericProperty
        {
            get { return info => info.GetType().IsGenericType; }
        }
        #endregion

        #region Other Property Methods
        public static PropertyInfo GetIndexProperty<TInstance>()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method Predicates
        public static Expression<Func<MethodInfo, bool>> IsPublicMethod
        {
            get { return info => info.IsPublic; }
        }
        public static Expression<Func<MethodInfo, bool>> IsAbstractMethod
        {
            get { return info => info.IsAbstract; }
        }

        public static Expression<Func<ConstructorInfo, bool>> IsGenericMethod
        {
            get { return info => info.IsGenericMethod; }
        }
        #endregion
    }
}
