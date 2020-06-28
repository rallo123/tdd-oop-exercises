using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static TestTools.Structure.Helper;

namespace TestTools.Structure
{
    public class ClassDefinition : Definition
    {
        public ClassDefinition(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
        public override string Name => FormatType(Type);

        public FieldDefinition Field(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            IEnumerable<MemberInfo> memberInfos = GetInstanceMembers().Where(m => m.Name.Equals(fieldName));
            AssertMemberExists(Type, fieldName, memberInfos);
            AssertMemberIs<FieldInfo>(Type, memberInfos.FirstOrDefault());
            
            FieldInfo fieldInfo = (FieldInfo)memberInfos.First();
            
            if (fieldType != null && fieldInfo.FieldType != fieldType)
                throw new AssertFailedException($"Instance field {fieldName} is not of type {FormatType(fieldType)}");

            if (accessLevel != null)
            {
                if (accessLevel == AccessLevel.Private && !fieldInfo.IsPrivate)
                    throw new AssertFailedException($"Instance field {fieldName} is not private");

                if (accessLevel == AccessLevel.Protected && !fieldInfo.IsFamily)
                    throw new AssertFailedException($"Instance field {fieldName} is not protected");

                if (accessLevel == AccessLevel.Public && !fieldInfo.IsPublic)
                    throw new AssertFailedException($"Instance field {fieldName} is not public");
            }

            return new FieldDefinition(fieldInfo) { PreviousDefinition = this };
        }

        public StaticFieldDefinition StaticField(string fieldName, Type fieldType = null, AccessLevel? accessLevel = null)
        {
            throw new NotImplementedException();
        }

        public PropertyDefinition Property(string propertyName, Type propertyType = null, GetMethod? getMethod = null, SetMethod? setMethod = null)
        {
            IEnumerable<MemberInfo> memberInfos = GetInstanceMembers().Where(m => m.Name.Equals(propertyName));
            AssertMemberExists(Type, propertyName, memberInfos);
            AssertMemberIs<PropertyInfo>(Type, memberInfos.First());

            PropertyInfo propertyInfo = (PropertyInfo)memberInfos.First();

            if (propertyType != null && propertyInfo.PropertyType != propertyType)
                throw new AssertFailedException($"Instance property {propertyName} is not of type {FormatType(propertyType)}");

            if (getMethod != null)
            {
                if (!propertyInfo.CanRead)
                    throw new AssertFailedException($"Instance property {propertyName} is missing get method");
                
                AssertMemberHasAccessLevel(Type, $"instance property {propertyName} get method", propertyInfo.GetMethod, getMethod?.AccessLevel);
            }

            if (setMethod != null)
            {
                if (!propertyInfo.CanWrite)
                    throw new AssertFailedException($"Instance property {propertyName} is missing set method");

                AssertMemberHasAccessLevel(Type, $"instance property {propertyName} set method", propertyInfo.SetMethod, setMethod?.AccessLevel);
            }

            return new PropertyDefinition(propertyInfo) { PreviousDefinition = this };
        }

        public StaticPropertyDefinition StaticProperty(string propertyName, Type propertyType, GetMethod? getMethod = null, SetMethod? setMethod = null)
        {
            throw new NotImplementedException();
        }

        public IAccessible FieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            if (GetInstanceMembers().OfType<FieldInfo>().Any(m => m.Name.Equals(memberName)))
            {
                return Field(memberName, memberType, accessLevel);
            }
            else if (GetInstanceMembers().OfType<PropertyInfo>().Any(m => m.Name.Equals(memberName)))
            {
                if (accessLevel == null)
                    return Property(memberName, memberType);

                else return Property(memberName, memberType, new GetMethod(accessLevel), new SetMethod(accessLevel));
            }
            else
            {
                throw new AssertFailedException($"{Type.Name} does not contain field/property {memberName}");
            }
        }

        public IStaticAccessible StaticFieldOrProperty(string memberName, Type memberType, AccessLevel? accessLevel = null)
        {
            throw new NotImplementedException();
        }

        public MethodDefinition Method(string methodName, Type returnType = null, Type[] parameterTypes = null, AccessLevel? accessLevel = null)
        {
            IEnumerable<MemberInfo> memberInfos = GetInstanceMembers().Where(m => m.Name.Equals(methodName));
            AssertMemberExists(Type, methodName, memberInfos);
            AssertMemberIs<MethodInfo>(Type, memberInfos.FirstOrDefault());

            string methodDeclartion = FormatMethodDeclaration(methodName, returnType, parameterTypes);
            IEnumerable<MethodInfo> methodInfos = memberInfos.OfType<MethodInfo>();
            MethodInfo methodInfo = methodInfos.FirstOrDefault(info => Helper.IsEachParameterOfExactType(info.GetParameters(), parameterTypes));
            
            if (methodInfo == null)
                throw new AssertFailedException($"{Type.Name} does not contain instance method {methodDeclartion}");

            if (returnType != null && methodInfo.ReturnType != returnType)
                throw new AssertFailedException($"Instance method {methodName} return type is not {FormatType(returnType)}");
            
            AssertMemberHasAccessLevel(Type, $"instance method {methodDeclartion}", methodInfo, accessLevel);

            return new MethodDefinition(methodInfo) { PreviousDefinition = this } ;
        }

        public StaticMethodDefinition StaticMethod(string methodName, Type returnType, Type[] parameterTypes = null, AccessLevel? accessLevel = null)
        {
            throw new NotImplementedException();
        }

        public ConstructorDefinition Constructor(Type[] parameterTypes = null, AccessLevel? accessLevel = null)
        {
            IEnumerable<ConstructorInfo> constructorInfos = GetInstanceMembers().OfType<ConstructorInfo>();
            ConstructorInfo constructorInfo = constructorInfos.FirstOrDefault(info => Helper.IsEachParameterOfExactType(info.GetParameters(), parameterTypes));
            string constructorDeclaration = FormatConstructorDeclaration(Type, parameterTypes);

            if (constructorInfo == null)
                throw new AssertFailedException($"{Type.Name} does not contain constructor {constructorDeclaration}");
            
            AssertMemberHasAccessLevel(Type, $"constructor {constructorDeclaration}", constructorInfo, accessLevel);

            return new ConstructorDefinition(constructorInfo) { PreviousDefinition = this };
        }

        public EventDefinition Event()
        {
            throw new NotImplementedException("Events are not supported yet");
        }

        public StaticEventDefinition StaticEvent()
        {
            throw new NotImplementedException("Static events are not supported yet");
        }

        IEnumerable<MemberInfo> GetInstanceMembers()
        {
            return Type.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        IEnumerable<MemberInfo> GetStaticMembers()
        {
            return Type.GetMembers(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        }

        static string GetMemberInfoTypeName(Type memberType)
        {
            static bool IsType(Type subtype, Type type) => subtype == type || subtype.IsSubclassOf(type);

            if (IsType(memberType, typeof(ConstructorInfo)))
                return "constructor";
            if (IsType(memberType, typeof(FieldInfo)))
                return "field";
            if (IsType(memberType, typeof(PropertyInfo)))
                return "property";
            if (IsType(memberType, typeof(MethodInfo)))
                return "method";

            throw new NotImplementedException();
        }

        static AccessLevel GetAccessLevel(MemberInfo memberInfo)
        {
            if (memberInfo is ConstructorInfo constructorInfo)
            {
                if (constructorInfo.IsPrivate)
                    return AccessLevel.Private;
                if (constructorInfo.IsFamily)
                    return AccessLevel.Protected;
                if (constructorInfo.IsPublic)
                    return AccessLevel.Public;
            }
            if (memberInfo is FieldInfo fieldInfo)
            {
                if (fieldInfo.IsPrivate)
                    return AccessLevel.Private;
                if (fieldInfo.IsFamily)
                    return AccessLevel.Protected;
                if (fieldInfo.IsPublic)
                    return AccessLevel.Public;
            }
            if (memberInfo is MethodInfo methodInfo)
            {
                if (methodInfo.IsPrivate)
                    return AccessLevel.Private;
                if (methodInfo.IsFamily)
                    return AccessLevel.Protected;
                if (methodInfo.IsPublic)
                    return AccessLevel.Public;
            }
            throw new NotImplementedException();
        }

        static void AssertMemberExists(Type type, string memberName, IEnumerable<MemberInfo> infos, bool isStatic = false)
        {
            if (!infos.Any())
            {
                if (!isStatic)
                    throw new AssertFailedException($"{type.Name} does not contain instance member {memberName}");

                else throw new AssertFailedException($"{type.Name} does not contain static member {memberName}");
            }
        }

        static void AssertMemberIs<T>(Type type, MemberInfo info, bool isStatic = false) where T : MemberInfo
        {
            if (info.GetType() == typeof(T) || info.GetType().IsSubclassOf(typeof(T)))
                return;

            string formattedType = Helper.FormatType(type);
            string formattedExpected = "a " + GetMemberInfoTypeName(typeof(T));
            string formattedActual = "a " + GetMemberInfoTypeName(info.GetType());

            if (!isStatic)
                throw new AssertFailedException($"{formattedType} instance member {info.Name} is {formattedActual} instead of {formattedExpected}");

            else throw new AssertFailedException($"{formattedType} static member {info.Name} is {formattedActual} instead of {formattedExpected}");
        }
        
        static void AssertMemberHasAccessLevel(Type type, string formattedMember, MemberInfo info, AccessLevel? accessLevel, bool isStatic = false)
        {
            if (accessLevel == null)
                return;

            if(GetAccessLevel(info) != accessLevel)
            {
                string formattedType = Helper.FormatType(type);
                string formattedAccessLevel = accessLevel.ToString().ToLower();

                if (!isStatic)
                    throw new AssertFailedException($"{formattedType} {formattedMember} is not {formattedAccessLevel}");

                else throw new AssertFailedException($"{formattedType} {formattedMember} is not {formattedAccessLevel}");
            }
        }
    }
}
