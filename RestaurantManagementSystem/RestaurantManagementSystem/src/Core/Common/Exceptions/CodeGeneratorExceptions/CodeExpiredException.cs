namespace RestaurantManagementSystem.Core.Common.Exceptions.CodeGeneratorExceptions
{
    public class CodeExpiredException : Exception
    {
        public CodeExpiredException(string message = " Code has Expired") : base(message) { }
    }
}
