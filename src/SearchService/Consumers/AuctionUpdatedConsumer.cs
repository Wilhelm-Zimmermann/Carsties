using AutoMapper;
using Contracts;
using MongoDB.Entities;
using MassTransit;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
    {
        private readonly IMapper _mapper;

        public AuctionUpdatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            Console.WriteLine("--> Consuming, auction updated");

            var item = _mapper.Map<Item>(context.Message);

            await item.SaveAsync();
        }
    }
}
