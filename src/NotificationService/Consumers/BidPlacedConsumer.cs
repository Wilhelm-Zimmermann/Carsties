using Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;

namespace NotificationService.Consumers;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    public readonly IHubContext<NotificationHub> _hubeContext;

    public BidPlacedConsumer(IHubContext<NotificationHub> hubeContext)
    {
        _hubeContext = hubeContext;
    }

    public async Task Consume(ConsumeContext<BidPlaced> context)
    {
        Console.WriteLine("==> bid placed message received");

        await _hubeContext.Clients.All.SendAsync("BidPlaced", context.Message);
    }
}
