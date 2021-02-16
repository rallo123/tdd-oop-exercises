using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace TestTools.Structure.Attributes
{
    public class AlternateNames : Attribute, ITypeTranslator, IMemberTranslator
    {
        string[] _alternateNames;

        public AlternateNames(params string[] alternateNames)
        {
            _alternateNames = alternateNames;
        }

        public StructureVerifier Verifier { get; set; }

        public Type Translate(string targetNamespace, Type type)
        {
            throw new NotImplementedException();
        }

        public MemberInfo Translate(Type targetType, MemberInfo member)
        {
            Verifier.VerifyTypeHasMember(targetType, new string[] { member.Name }.Union(_alternateNames).ToArray());

            IEnumerable<MemberInfo> members = targetType.GetMembers().Where(m => m.Name == member.Name || _alternateNames.Contains(m.Name));
            
            // Multiple MethodBase members may have the same name and only differ in argument list
            if (member is MethodBase methodBase1)
            {
                foreach(var methodBase2 in members.OfType<MethodBase>())
                {
                    var parameterTypes1 = methodBase1.GetParameters().Select(p => p.ParameterType);
                    var parameterTypes2 = methodBase2.GetParameters().Select(p => p.ParameterType);

                    if (parameterTypes1.SequenceEqual(parameterTypes2))
                        return methodBase2;
                }
            }
            return members.First();
        }
    }
}
