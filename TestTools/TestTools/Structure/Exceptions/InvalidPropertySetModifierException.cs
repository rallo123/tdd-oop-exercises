using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidPropertySetModifierException : InvalidStructureException
    {
        public InvalidPropertySetModifierException(Type @class, PropertyOptions options, MemberModifiers modifier, bool shouldHaveModifer = true) 
            : base (shouldHaveModifer ? "{0}.{1}'s set is not {2}" : "{0}.{1}'s set is {2}", FormatType(@class), options.Name, FormatMemberModifier(modifier))
        {
            Type = @class;
            Options = options;
            Modifier = modifier;
            ShouldHaveModifier = shouldHaveModifer;
        }

        public Type Type { get; }
        public PropertyOptions Options { get; }
        public MemberModifiers Modifier { get; }
        public bool ShouldHaveModifier { get; }
    }
}
