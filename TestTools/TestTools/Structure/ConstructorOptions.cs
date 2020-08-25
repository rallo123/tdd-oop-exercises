using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTools.Structure
{
    public class ConstructorOptions
    {
        public ConstructorOptions() 
            : this(new Type[0])
        { 
        }

        public ConstructorOptions(params Type[] types) 
            : this(types.Select(t => new ParameterOptions(t)).ToArray())
        {
        }

        public ConstructorOptions(params ParameterOptions[] parameters)
        {
            IsPrivate = null;
            IsFamily = null;
            IsPublic = null;

            Parameters = parameters ?? new ParameterOptions[0];
        }

        public bool? IsPrivate { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsPublic { get; set; }

        public ParameterOptions[] Parameters { get; set; }

        public void OverwriteTypes(Type[] parameterTypes)
        {

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
