namespace TestTools.Structure
{
    public struct GetMethod
    {
        public AccessLevel? AccessLevel { get; }
        
        public GetMethod(AccessLevel? accessLevel = null)
        {
            AccessLevel = accessLevel;
        }
    }
}
