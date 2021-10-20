using IdentityServer4.Models;
using System.Collections.Generic;

namespace Surfbreak.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope()
                    {
                        Name = "SurfbreakApi",
                        Emphasize = true
                    }
                };
            }
        }
        public static IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",
                        AllowedScopes = {"SurfbreakApi"},
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = 
                        {
                            new Secret("hest".Sha256())
                        }
                    }
                };
            }
        }
    }
}