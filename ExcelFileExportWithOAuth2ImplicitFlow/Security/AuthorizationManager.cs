using System.Security.Claims;

namespace ExcelFileExportWithOAuth2ImplicitFlow.Security
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            // This is where you can authorise the user if you
            // have special roles etc, database checks or whatever
            return true;
        }
    }
}