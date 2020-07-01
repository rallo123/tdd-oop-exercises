using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public interface IStaticMemberable
    {
        StaticFieldDefinition<T> Field<T>(string fieldName, AccessLevel? accessLevel = null);
        StaticFieldDefinition<T> StaticField<T>(string fieldName, AccessLevel? accessLevel = null);

        StaticPropertyDefinition<T> Property<T>(string propertyName, PropertyAccessor get = null, PropertyAccessor set = null);
        StaticPropertyDefinition<T> StaticProperty<T>(string propertyName, PropertyAccessor get = null, PropertyAccessor set = null);
        
        IStaticAccessible<T> FieldOrProperty<T>(string memberName, AccessLevel? accessLevel = null);
        IStaticAccessible<T> StaticFieldOrProperty<T>(string memberName, AccessLevel? accessLevel = null);

        StaticMethodDefinition<TReturn> Method<TReturn>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1> Method<TReturn, T1>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2> Method<TReturn, T1, T2>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3> Method<TReturn, T1, T2, T3>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4> Method<TReturn, T1, T2, T3, T4>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4, T5> Method<TReturn, T1, T2, T3, T4, T5>(string methodName, AccessLevel? accessLevel = null);

        StaticMethodDefinition<TReturn> StaticMethod<TReturn>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1> StaticMethod<TReturn, T1>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2> StaticMethod<TReturn, T1, T2>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3> StaticMethod<TReturn, T1, T2, T3>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4> StaticMethod<TReturn, T1, T2, T3, T4>(string methodName, AccessLevel? accessLevel = null);
        StaticMethodDefinition<TReturn, T1, T2, T3, T4, T5> StaticMethod<TReturn, T1, T2, T3, T4, T5>(string methodName, AccessLevel? accessLevel = null);

        //event
    }
}
