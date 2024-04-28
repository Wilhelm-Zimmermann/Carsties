using Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;

namespace NotificationService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    public readonly IHubContext<NotificationHub> _hubeContext;

    public AuctionCreatedConsumer(IHubContext<NotificationHub> hubeContext)
    {
        _hubeContext = hubeContext;
    }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("==> auction created message received");

        await _hubeContext.Clients.All.SendAsync("AuctionCreated", context.Message);
    }
}
