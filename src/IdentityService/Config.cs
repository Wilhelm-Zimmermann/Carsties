using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("auctionApp", "Auction app full access"),
        ];

    public static IEnumerable<Client> Clients =>
        [
            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes = {"openid", "profile", "auctionApp" },
                RedirectUris = {"https://www.google.com" },
                ClientSecrets = [new Secret("Segredo".Sha256())],
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
            },            
            new Client
            {
                ClientId = "nextapp",
                ClientName = "nextApp",
                AllowedScopes = {"openid", "profile", "auctionApp" },
                RedirectUris = {"http://localhost:3000/api/auth/callback/id-server"},
                ClientSecrets = [new Secret("Segredos".Sha256())],
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                RequirePkce = false,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 3600 * 24 * 30
            }
        ];
}
