using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public interface IMemberable<TClass>
    {
        FieldDefinition<TClass, T> Field<T>(string fieldName, AccessLevel? accessLevel = null);
        StaticFieldDefinition<T> StaticField<T>(string fieldName, AccessLevel? accessLevel = null);

        PropertyDefinition<TClass, T> Property<T>(string propertyName, PropertyAccessor get = null, PropertyAccessor set = null);
        StaticPropertyDefinition<T> StaticProperty<T>(string propertyName, PropertyAccessor get = null, PropertyAccessor set = null);

        IAccessible<TClass, T> FieldOrProperty<T>(string memberName, AccessLevel? accessLevel = null);
        IStaticAccessible<T> StaticFieldOrProperty<T>(string memberName, AccessLevel? accessLevel = null);

        MethodDefinition<TClass, TReturn> Method<TReturn>(string methodName, AccessLevel? accessLevel = null);
        MethodDefinition<TClass, TReturn, T1> Method<TReturn, T1>(string methodName, AccessLevel? accessLevel = null);
        MethodDefinition<TClass, TReturn, T1, T2> Method<TReturn, T1, T2>(string methodName, AccessLevel? accessLevel = null);
        MethodDefinition<TClass, TReturn, T1, T2, T3> Method<TReturn, T1, T2, T3>(string methodName, AccessLevel? accessLevel = null);
        MethodDefinition<TClass, TReturn, T1, T2, T3, T4> Method<TReturn, T1, T2, T3, T4>(string methodName, AccessLevel? accessLevel = null);
        MethodDefinition<TClass, TReturn, T1, T2, T3, T4, T5> Method<TReturn, T1, T2, T3, T4, T5>(string methodName, AccessLevel? accessLevel = null);

        StaticMethodDefinition<TReturn> StaticMethod<TReturn>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1> StaticMethod<TReturn, T1>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2> StaticMethod<TReturn, T1, T2>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3> StaticMethod<TReturn, T1, T2, T3>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4> StaticMethod<TReturn, T1, T2, T3, T4>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4, T5> StaticMethod<TReturn, T1, T2, T3, T4, T5>(string methodName, AccessLevel? accessLevel = null);

        //events
    }
}
