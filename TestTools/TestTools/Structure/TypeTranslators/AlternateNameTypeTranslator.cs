using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace TestTools.Structure
{
    public class AlternateNameTypeTranslator : TypeTranslator
    {
        string[] _alternateNames;

        public AlternateNameTypeTranslator(params string[] alternateNames)
        {
            _alternateNames = alternateNames;
        }

        public override Type Translate(Type type)
        {
            string[] names = _alternateNames.Union(new[] { type.Name }).ToArray();

            foreach (string name in names)
            {
                Type translatedType = Assembly.Load(type.Name).GetTypes().SingleOrDefault(t => t.Namespace == TargetNamespace);

                if (translatedType == null)
                    return translatedType;
            }

            Verifier.FailTypeNotFound(TargetNamespace, names);
            
            return null;  
        }
    }
}
