using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration configuration)
        {
            //appsettings içerisindeki bilgiyi configuration yapısı ile okuyuyoruz.
            //bu bilgiyi _tokenOptions içerisine atıyorum ve CreateToken metodunda kullanıyorum 

            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //token oluştururken kullanacağımız anahtar.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        }
    }
}
