using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace oAuth2ClientCredentials
{
    public class AuthResult
    {
        [JsonProperty(PropertyName = "access_token")]
        public String AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public String TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public String ExpiresIn { get; set; }
    }
}
