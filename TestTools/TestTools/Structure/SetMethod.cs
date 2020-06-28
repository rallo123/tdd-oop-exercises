namespace TestTools.Structure
{
    public struct SetMethod
    {
        public AccessLevel? AccessLevel { get; }

        public SetMethod(AccessLevel? accessLevel = null)
        {
            AccessLevel = accessLevel;
        }
    }
}
