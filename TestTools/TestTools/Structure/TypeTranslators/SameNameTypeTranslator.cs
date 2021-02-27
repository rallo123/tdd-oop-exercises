using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace TestTools.Structure
{
    public class SameNameTypeTranslator : TypeTranslator
    {
        public override Type Translate(Type type)
        {
            Type translatedType = Assembly.Load(type.Name).GetTypes().SingleOrDefault(t => t.Namespace == TargetNamespace);

            if (translatedType is null)
                Verifier.FailTypeNotFound(TargetNamespace, new[] { type.Name });

            return type;
        }
    }
}
