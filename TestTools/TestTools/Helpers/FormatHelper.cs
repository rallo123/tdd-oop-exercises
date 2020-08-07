using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Structure;

namespace TestTools.Helpers
{
    public static class FormatHelper
    {
        public static string FormatAccessLevel(AccessLevel accessLevel)
        {
            return accessLevel.ToString().ToLower();
        }

        public static string FormatMethodDeclaration(string methodName, Type returnType, Type[] parameterTypes)
        {
            return FormatType(returnType) + " " + methodName + "(" + FormatParameters(parameterTypes) + ")";
        }

        public static string FormatConstructorDeclaration(Type classType, Type[] parameterTypes)
        {
            return FormatType(classType) + "(" + FormatParameters(parameterTypes) + ")";
        }

        private static string FormatParameters(Type[] parameterTypes)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < parameterTypes.Length; i++)
            {
                if (i != 0)
                    builder.Append(", ");

                builder.Append($"{FormatType(parameterTypes[i])} par{i + 1}");
            }
            return builder.ToString();
        }

        public static string FormatMemberType(Type memberType)
        {
            if (memberType == null)
                throw new ArgumentNullException(nameof(memberType));
            if (memberType.IsSubclassOf(memberType))
                throw new ArgumentException($"Type {memberType.Name} is subtype of MemberInfo");

            if (TypeHelper.IsType(typeof(FieldInfo), memberType))
                return "field";
            if (TypeHelper.IsType(typeof(PropertyInfo), memberType))
                return "property";
            if (TypeHelper.IsType(typeof(MethodInfo), memberType))
                return "method";
            if (TypeHelper.IsType(typeof(ConstructorInfo), memberType))
                return "constructor";

            throw new NotImplementedException("Unknown MemberInfo type");
        }

        public static string FormatType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Dictionary<Type, string> BuiltinTypes = new Dictionary<Type, string>()
            {
                [typeof(void)] = "void",
                [typeof(bool)] = "bool",
                [typeof(int)] = "int",
                [typeof(byte)] = "byte",
                [typeof(sbyte)] = "sbyte",
                [typeof(char)] = "char",
                [typeof(decimal)] = "decimal",
                [typeof(double)] = "double",
                [typeof(float)] = "float",
                [typeof(int)] = "int",
                [typeof(uint)] = "uint",
                [typeof(long)] = "long",
                [typeof(ulong)] = "ulong",
                [typeof(short)] = "short",
                [typeof(ushort)] = "ushort",
                [typeof(string)] = "string",
                [typeof(object)] = "object"
            };

            if (BuiltinTypes.ContainsKey(type))
                return BuiltinTypes[type];

            else return type.Name;
        }

        public static string FormatDefinitionChain(Definition definition)
        {
            string prefix = "";

            if (definition.PreviousDefinition != null)
                prefix += ".";

            return prefix + definition.Name;
        }
    }
}
