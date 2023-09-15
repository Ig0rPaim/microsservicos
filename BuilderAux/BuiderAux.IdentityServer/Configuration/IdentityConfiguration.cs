using Duende.IdentityServer.Models;
using Duende.IdentityServer;
using System.Collections.Generic;

namespace BuiderAux.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string NormalUser = "NormalUser";

        //Identity Resource
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        //Identity Scope. identificadores ou recursos que um client pode acessar, ccontem um obj com as informações do perfil
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("LoginAPI", "LoginAPIServer"),
            new ApiScope("Read", "Read Data."),
            new ApiScope("Write", "Write Data."),
            new ApiScope("Delete", "Delete Data."),
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "Client",
                ClientSecrets = {new Secret("my_super_secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"Read", "Write", "Profile"}
            },
            //new Client
            //{
            //    ClientId = "BuilderAux",
            //    ClientSecrets = {new Secret("my_super_secret".Sha256())},
            //    AllowedGrantTypes = GrantTypes.Code,
            //    RedirectUris = {"http://localhost:5183/sigin-oidc"},
            //    PostLogoutRedirectUris = {"http://localhost:5183/sigout-oidc"},
            //    AllowedScopes = new List<string>
            //    {
            //        IdentityServerConstants.StandardScopes.OpenId,
            //        IdentityServerConstants.StandardScopes.Email,
            //        IdentityServerConstants.StandardScopes.Profile,
            //        "BuilderAux"
            //    }
            //}
        };

    }
}

