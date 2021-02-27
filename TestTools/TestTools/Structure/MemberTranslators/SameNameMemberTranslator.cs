using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class SameNameMemberTranslator : MemberTranslator
    {
        public override MemberInfo Translate(MemberInfo member)
        {
            IEnumerable<MemberInfo> members = TargetType.GetMembers().Where(m => m.Name == member.Name);

            if (!members.Any())
                Verifier.FailMemberNotFound(TargetType, new[] { member.Name });

            // Multiple MethodBase members may have the same name and only differ in argument list
            if (member is MethodBase methodBase1)
            {
                foreach (var methodBase2 in members.OfType<MethodBase>())
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
