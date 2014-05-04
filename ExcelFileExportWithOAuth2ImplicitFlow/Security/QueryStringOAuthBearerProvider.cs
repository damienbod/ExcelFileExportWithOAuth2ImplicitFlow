using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;

namespace ExcelFileExportWithOAuth2ImplicitFlow.Security
{
    /// <summary>
    /// This class is required if standard header bearer authentifaction cannot be used. This helper method helps get the resource from a different location.
    /// From http://leastprivilege.com/2013/10/31/retrieving-bearer-tokens-from-alternative-locations-in-katanaowin/
    /// </summary>
    public class QueryStringOAuthBearerProvider : OAuthBearerAuthenticationProvider
    {
        readonly string _name;

        public QueryStringOAuthBearerProvider(string name)
        {
            _name = name;
        }

        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            var value = context.Request.Query.Get(_name);

            if (!string.IsNullOrEmpty(value))
            {
                context.Token = value;
            }

            return Task.FromResult<object>(null);
        }
    }
}