using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ClassDefinition : Definition, IMemberable
    {
        public ClassDefinition(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
        public override string Name => FormatHelper.FormatType(Type);
        
        public FieldDefinition Field(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            FieldInfo fieldInfo = StructureHelper.GetFieldInfo(Type, fieldName, fieldType, accessLevel, isStatic: false);
            return new FieldDefinition(fieldInfo) { PreviousDefinition = this };
        }

        public StaticFieldDefinition StaticField(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            FieldInfo fieldInfo = StructureHelper.GetFieldInfo(Type, fieldName, fieldType, accessLevel, isStatic: true);
            return new StaticFieldDefinition(fieldInfo) { PreviousDefinition = this };
        }

        public PropertyDefinition Property(string propertyName, Type propertyType = null, PropertyAccessor get = null, PropertyAccessor set = null)
        {
            PropertyInfo propertyInfo = StructureHelper.GetPropertyInfo(Type, propertyName, propertyType, get, set, isStatic: false);
            return new PropertyDefinition(propertyInfo) { PreviousDefinition = this };
        }

        public StaticPropertyDefinition StaticProperty(string propertyName, Type propertyType, PropertyAccessor get = null, PropertyAccessor set = null)
        {
            PropertyInfo propertyInfo = StructureHelper.GetPropertyInfo(Type, propertyName, propertyType, get, set, isStatic: true);
            return new StaticPropertyDefinition(propertyInfo) { PreviousDefinition = this };
        }

        public IAccessible FieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            MemberInfo memberInfo = StructureHelper.GetFieldOrPropertyInfo(Type, memberName, memberType, accessLevel, isStatic: false);

            if (memberInfo is FieldInfo fieldInfo)
                return new FieldDefinition(fieldInfo) { PreviousDefinition = this };
            if (memberInfo is PropertyInfo propertyInfo)
                return new PropertyDefinition(propertyInfo) { PreviousDefinition = this };

            throw new NotImplementedException();
        }

        public IStaticAccessible StaticFieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            MemberInfo memberInfo = StructureHelper.GetFieldOrPropertyInfo(Type, memberName, memberType, accessLevel, isStatic: true);

            if (memberInfo is FieldInfo fieldInfo)
                return new StaticFieldDefinition(fieldInfo) { PreviousDefinition = this };
            if (memberInfo is PropertyInfo propertyInfo)
                return new StaticPropertyDefinition(propertyInfo) { PreviousDefinition = this };

            throw new NotImplementedException("INTERNAL: memberInfo is not field or property");
        }

        public MethodDefinition Method(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            MethodInfo methodInfo = StructureHelper.GetMethodInfo(Type, methodName, returnType, parameterTypes, accessLevel, isStatic: false);
            return new MethodDefinition(methodInfo) { PreviousDefinition = this };
        }

        public StaticMethodDefinition StaticMethod(string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            MethodInfo methodInfo = StructureHelper.GetMethodInfo(Type, methodName, returnType, parameterTypes, accessLevel, isStatic: true);
            return new StaticMethodDefinition(methodInfo) { PreviousDefinition = this };
        }

        //events

        public ConstructorDefinition Constructor(Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            ConstructorInfo constructorInfo = StructureHelper.GetConstructorInfo(Type, parameterTypes, accessLevel);
            return new ConstructorDefinition(constructorInfo) { PreviousDefinition = this };
        }
    }
}
