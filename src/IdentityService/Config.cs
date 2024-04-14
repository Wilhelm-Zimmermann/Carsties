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
            }
        ];
}
