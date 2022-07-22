using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace IdentityAutorisationWithDotNet5
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("MyWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                // позволяет видеть утверждения о пользователе имя/дата рождения
                new IdentityResources.Profile()
            };

        // доступ ко всему защищунному ресурсу 
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("MyWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = {"MyWebAPI"}
                }
            };
        // даем знать каким клиенским приложениям позволено его использовать 
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "my-web-api",
                    ClientName = "My Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    // переход после авторизации
                    RedirectUris =
                    {
                        "http://.../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    // переход после выхода 
                    PostLogoutRedirectUris =
                    {
                        "http:/.../signout-oidc"
                    },
                    // области доступные клиенту 
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MyWebAPI"
                    },
                    // передача токена через браузер 
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
