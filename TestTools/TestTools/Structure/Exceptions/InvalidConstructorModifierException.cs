using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidConstructorModifierException : InvalidStructureException
    {
        public InvalidConstructorModifierException(Type @class, ConstructorOptions options, MemberModifiers modifier, bool shouldHaveModifer = true)
            : base(shouldHaveModifer ? "{0} constructor {1} is not {2}" : "{0} constructor {1} is {2}", FormatType(@class), FormatConstructorDeclaration(@class, options), FormatMemberModifier(modifier)) 
        {
            Type = @class;
            Options = options;
            Modifier = modifier;
            ShouldHaveModifier = shouldHaveModifer;
        }

        public Type Type { get; }
        public ConstructorOptions Options { get; }
        public MemberModifiers Modifier { get; }
        public bool ShouldHaveModifier { get; }
    }
}
