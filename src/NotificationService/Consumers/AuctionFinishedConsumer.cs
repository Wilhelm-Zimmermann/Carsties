using Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;

namespace NotificationService.Consumers;

public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    public readonly IHubContext<NotificationHub> _hubeContext;

    public AuctionFinishedConsumer(IHubContext<NotificationHub> hubeContext)
    {
        _hubeContext = hubeContext;
    }

    public async Task Consume(ConsumeContext<AuctionFinished> context)
    {
        Console.WriteLine("==> auction finished message received");

        await _hubeContext.Clients.All.SendAsync("AuctionFinished", context.Message);
    }
}
