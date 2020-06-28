using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace TestTools.Structure
{
    internal static class Helper
    {
        public static bool IsNullable(Type type)
        {
            if (type.IsValueType)
                return Nullable.GetUnderlyingType(type) != null;

            return true;
        }
        public static bool IsOfType(object value, Type type)
        {
            if (value == null && !IsNullable(type))
                return false;

            if (value != null && ! (value.GetType() == type || value.GetType().IsSubclassOf(type)))
                return false;

            return true;
        }

        public static bool IsEachParameterOfExactType(IEnumerable<ParameterInfo> parameterInfos, IEnumerable<Type> parameterTypes)
        {
            //Method is parameterless
            if (parameterTypes == null)
                return parameterInfos.Count(p => !p.IsOptional) == 0;

            ParameterInfo info = parameterInfos.FirstOrDefault();
            Type type = parameterTypes.FirstOrDefault();
            
            //last parameter matches last type
            if (info == null && type == null)
                return true;
            //too few parameters
            else if (info == null && type != null)
                return false;
            //too many parameters
            else if (type == null && !info.IsOptional)
                return false;
            //parameter does not match type
            else if (type != null && info.ParameterType != type)
                return false;

            return IsEachParameterOfExactType(parameterInfos.Skip(1), parameterTypes.Skip(1));
        }

        public static void CheckEachParameterIsOfExactType(IEnumerable<ParameterInfo> parameterInfos, IEnumerable<Type> parameterTypes)
        {
            //Method is parameterless
            if (parameterTypes == null && parameterInfos.Count(p => !p.IsOptional) == 0)
                throw new AssertFailedException("Too many parameters");

            ParameterInfo info = parameterInfos.FirstOrDefault();
            Type type = parameterTypes.FirstOrDefault();

            //last parameter matches last type
            if (info == null && type == null)
                return;
            //too few parameters
            else if (info == null && type != null)
                throw new AssertFailedException("Too few parameters");
            //too many parameters
            else if (type == null && !info.IsOptional)
                throw new AssertFailedException("Too many parameters");
            //parameter does not match type
            else if (type != null && info.ParameterType != type)
                throw new AssertFailedException("Type mismatch");

            CheckEachParameterIsOfExactType(parameterInfos.Skip(1), parameterTypes.Skip(1));
        }

        public static bool IsEachArgumentOfType(IEnumerable<ParameterInfo> infos, IEnumerable<object> arguments)
        {
            //Method is parameterless
            if (arguments == null)
                return infos.Count(p => !p.IsOptional) == 0;

            //last parameter matches last type
            if (!infos.Any() && !arguments.Any())
                return true;
            //too few parameters
            else if (!infos.Any() && arguments.Any())
                return false;
            //too many parameters
            else if (!arguments.Any() && !infos.First().IsOptional)
                return false;
            //parameter does not match type
            else if (arguments.Any() && !IsOfType(arguments.First(), infos.First().ParameterType))
                return false;

            return IsEachArgumentOfType(infos.Skip(1), arguments.Skip(1));
        }

        public static void CheckEachArgumentIsOfType(IEnumerable<ParameterInfo> infos, IEnumerable<object> arguments)
        {
            //Method is parameterless
            if (arguments == null && infos.Count(p => !p.IsOptional) != 0)
                throw new AssertFailedException("Too few arguments");
            if (arguments == null)
                return;

            //last parameter matches last type
            if (!infos.Any() && !arguments.Any())
                return;
            //too few parameters
            else if (!infos.Any() && arguments.Any())
                throw new AssertFailedException("Too many arguments");
            //too many parameters
            else if (!arguments.Any() && !infos.First().IsOptional)
                throw new AssertFailedException("Too few arguments");
            //parameter does not match type
            else if (arguments.Any() && !IsOfType(arguments.First(), infos.First().ParameterType))
            {
                string formattedArgument = ObjectMethodRegistry.ToString(arguments.First());
                string formattedType = FormatType(infos.First().ParameterType);

                throw new AssertFailedException($"Parameter {infos.First().Name} argument {formattedArgument} is not of type {formattedType}");
            }
            CheckEachArgumentIsOfType(infos.Skip(1), arguments.Skip(1));
        }
        
        public static object[] GetArguments(ParameterInfo[] infos, object[] arguments)
        {
            List<object> formattedArguments = new List<object>();

            int argIndex = 0; 
            for(int parIndex = 0; parIndex < infos.Length; parIndex++)
            {
                if (argIndex < arguments.Length &&  IsOfType(arguments[argIndex], infos[parIndex].ParameterType))
                {
                    formattedArguments.Add(arguments[argIndex]);
                    argIndex++;
                }
                else formattedArguments.Add(infos[parIndex].DefaultValue);
            }
            return formattedArguments.ToArray();
        }

        public static string FormatType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type cannot be null");

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

        public static string FormatParameterDeclaration(Type[] parameterTypes)
        {
            StringBuilder builder = new StringBuilder();

            if (parameterTypes != null)
            {
                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    if (i != 0)
                        builder.Append(", ");

                    builder.Append($"{FormatType(parameterTypes[i])} par{i + 1}");
                }
            }

            return builder.ToString();
        }

        public static string FormatFieldDeclaration(string memberName, Type type)
        {
            if (type == null)
                throw new ArgumentException("Field type cannot be null");

            return $"{FormatType(type)} {memberName}";
        }

        public static string FormatPropertyDeclaration(string memberName, Type type)
        {
            if (type == null)
                throw new ArgumentException("Property type cannot be null");

            return $"{FormatType(type)} {memberName}";
        }

        public static string FormatMethodDeclaration(string methodName, Type returnType, Type[] parameterTypes)
        {
            if (parameterTypes?.Any(t => t == null) ?? false)
                throw new ArgumentNullException("Parameter types cannot contain null");

            return $"{FormatType(returnType)} {methodName}({FormatParameterDeclaration(parameterTypes)})";
        }

        public static string FormatConstructorDeclaration(Type classType, Type[] parameterTypes)
        {
            if (parameterTypes?.Any(t => t == null) ?? false)
                throw new ArgumentNullException("Parameter types cannot contain null");

            return $"{FormatType(classType)}({FormatParameterDeclaration(parameterTypes)})";
        }
    }
}
