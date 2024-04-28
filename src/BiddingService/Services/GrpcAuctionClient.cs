using AuctionService;
using BiddingService.Models;
using Grpc.Net.Client;

namespace BiddingService.Services;

public class GrpcAuctionClient
{
    public readonly ILogger<GrpcAuctionClient> _logger;
    private readonly IConfiguration _configuration;

    public GrpcAuctionClient(ILogger<GrpcAuctionClient> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public Auction GetAuction(string id)
    {
        _logger.LogInformation("Calling grpc");

        var channel = GrpcChannel.ForAddress(_configuration["GrpcAuction"]);
        var client = new GrpcAuction.GrpcAuctionClient(channel);
        var request = new GetAuctionRequest
        {
            Id = id,
        };

        try
        {
            var reply = client.GetAuction(request);
            var auction = new Auction
            {
                ID = reply.Auction.Id,
                AuctionEnd = DateTime.Parse(reply.Auction.AuctionEnd),
                Seller = reply.Auction.Seller,
                ReservedPrice = reply.Auction.ReservedPrice
            };

            return auction;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could no call GRPC");
            return null;
        }
    }
}
