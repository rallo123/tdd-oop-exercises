using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidMethodModifierException : InvalidStructureException
    {
        public InvalidMethodModifierException(Type @class, MethodRequirements options, MemberModifiers modifier, bool shouldHaveModifer = true)
            : base(shouldHaveModifer ? "{0}.{1} is not {2}" : "{0}.{1} is {2}", FormatType(@class), FormatMethodAccess(@class, options), FormatMemberModifier(modifier))
        {
            Type = @class;
            Options = options;
            Modifier = modifier;
            ShouldHaveModifier = shouldHaveModifer;
        }

        public Type Type { get; }
        public MethodRequirements Options { get; }
        public MemberModifiers Modifier { get; }
        public bool ShouldHaveModifier { get; }
    }
}
