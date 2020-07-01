using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class StaticPropertyDefinition : Definition, IStaticAccessible, IStaticMemberable
    {
        public StaticPropertyDefinition(PropertyInfo propertyInfo)
        {
            Info = propertyInfo;
        }

        public PropertyInfo Info { get; }
        public override string Name => Info.Name;

        public object Get()
        {
            throw new NotImplementedException();
        }

        public object Set(object value)
        {
            throw new NotImplementedException();
        }


        public StaticFieldDefinition Field(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            FieldInfo fieldInfo = StructureHelper.GetFieldInfo(Info.PropertyType, fieldName, fieldType, accessLevel, isStatic: false);
            return new StaticFieldDefinition(fieldInfo) { PreviousDefinition = this };
        }

        public StaticFieldDefinition StaticField(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            FieldInfo fieldInfo = StructureHelper.GetFieldInfo(Info.PropertyType, fieldName, fieldType, accessLevel, isStatic: true);
            return new StaticFieldDefinition(fieldInfo) { PreviousDefinition = this };
        }

        public StaticPropertyDefinition Property(string propertyName, Type propertyType = null, PropertyAccessor get = null, PropertyAccessor set = null)
        {
            PropertyInfo propertyInfo = StructureHelper.GetPropertyInfo(Info.PropertyType, propertyName, propertyType, get, set, isStatic: false);
            return new StaticPropertyDefinition(propertyInfo) { PreviousDefinition = this };
        }

        public StaticPropertyDefinition StaticProperty(string propertyName, Type propertyType, PropertyAccessor get = null, PropertyAccessor set = null)
        {
            PropertyInfo propertyInfo = StructureHelper.GetPropertyInfo(Info.PropertyType, propertyName, propertyType, get, set, isStatic: true);
            return new StaticPropertyDefinition(propertyInfo) { PreviousDefinition = this };
        }

        public IStaticAccessible FieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            MemberInfo memberInfo = StructureHelper.GetFieldOrPropertyInfo(Info.PropertyType, memberName, memberType, accessLevel, isStatic: false);

            if (memberInfo is FieldInfo fieldInfo)
                return new StaticFieldDefinition(fieldInfo);
            if (memberInfo is PropertyInfo propertyInfo)
                return new StaticPropertyDefinition(propertyInfo);

            throw new NotImplementedException();
        }

        public IStaticAccessible StaticFieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            MemberInfo memberInfo = StructureHelper.GetFieldOrPropertyInfo(Info.PropertyType, memberName, memberType, accessLevel, isStatic: true);

            if (memberInfo is FieldInfo fieldInfo)
                return new StaticFieldDefinition(fieldInfo);
            if (memberInfo is PropertyInfo propertyInfo)
                return new StaticPropertyDefinition(propertyInfo);

            throw new NotImplementedException("INTERNAL: memberInfo is not field or property");
        }

        public StaticMethodDefinition Method(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            MethodInfo methodInfo = StructureHelper.GetMethodInfo(Info.PropertyType, methodName, returnType, parameterTypes, accessLevel, isStatic: false);
            return new StaticMethodDefinition(methodInfo) { PreviousDefinition = this };
        }

        public StaticMethodDefinition StaticMethod(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            MethodInfo methodInfo = StructureHelper.GetMethodInfo(Info.PropertyType, methodName, returnType, parameterTypes, accessLevel, isStatic: true);
            return new StaticMethodDefinition(methodInfo) { PreviousDefinition = this };
        }

        //events
    }
}
