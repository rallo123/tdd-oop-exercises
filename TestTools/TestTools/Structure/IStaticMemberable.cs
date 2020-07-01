using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    interface IStaticMemberable
    {
        public StaticFieldDefinition Field(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null);
        public StaticFieldDefinition StaticField(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null);

        public StaticPropertyDefinition Property(string propertyName, Type propertyType = null, PropertyAccessor get = null, PropertyAccessor set = null);
        public StaticPropertyDefinition StaticProperty(string propertyName, Type propertyType, PropertyAccessor get = null, PropertyAccessor set = null);

        public IStaticAccessible FieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null);

        public IStaticAccessible StaticFieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null);

        public StaticMethodDefinition Method(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null);
        public StaticMethodDefinition StaticMethod(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null);
        
        //events
    }
}
