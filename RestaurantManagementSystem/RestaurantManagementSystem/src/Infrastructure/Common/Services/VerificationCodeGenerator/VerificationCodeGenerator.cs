using shortid;
using shortid.Configuration;

namespace RestaurantManagementSystem.Infrastructure.Common.Services.VerificationCodeGenerator
{
    public static class VerificationCodeGenerator
    {
        public static string Generate()
        {
            //for specifing what random code contains
            var options = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: 8);
            string verificationcode = ShortId.Generate(options);
            return verificationcode;
        }
    }
}
