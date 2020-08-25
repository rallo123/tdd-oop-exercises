using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTools.Structure
{
    // based upon System.Reflection.MethodInfo
    public class MethodOptions
    {
        public MethodOptions()
            : this(null)
        { 
        }

        public MethodOptions(string name)
            : this(name, null, new ParameterOptions[0])
        {
        }

        public MethodOptions(string name, Type returnType, params Type[] parameterTypes) 
            : this(name, returnType, parameterTypes.Select(t => new ParameterOptions(t)).ToArray())
        {
        }

        public MethodOptions(string name, Type returnType, params ParameterOptions[] parameters)
        {
            Name = name;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public string Name { get; set; }

        public Type ReturnType { get; set; }

        public bool? IsPrivate { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsPublic { get; set; }

        public bool? IsVirtual { get; set; }

        public bool? IsAbstract { get; set; }

        public Type DeclaringType { get; set; }

        public ParameterOptions[] Parameters { get; set; }

        public void OverwriteTypes(Type returnType, Type[] parameterTypes)
        {
            ReturnType = returnType;

            if (parameterTypes.Length == 0)
            {
                Parameters = new ParameterOptions[0];
                return;
            }

            if (Parameters.Length > parameterTypes.Length)
                throw new ArgumentException("parametersTypes is shorter than options.Parameters");

            if (Parameters.Length < parameterTypes.Length)
            {
                ParameterOptions[] buffer = new ParameterOptions[parameterTypes.Length];
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (Parameters.Length < i - 1)
                    {
                        buffer[i] = Parameters[i];
                        buffer[i].ParameterType = parameterTypes[i];
                    }
                    else buffer[i] = new ParameterOptions(parameterTypes[i]);
                }
                Parameters = buffer;
            }
        }
    }
}
