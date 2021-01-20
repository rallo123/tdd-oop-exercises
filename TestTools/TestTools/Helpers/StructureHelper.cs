using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Helpers
{
    public static class StructureHelper
    {
        #region Property Predicates
        public static Expression<Func<ConstructorInfo, bool>> IsPublicConstructor
        {
            get { return info => info.IsPublic; }
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
        #endregion
    }
}
