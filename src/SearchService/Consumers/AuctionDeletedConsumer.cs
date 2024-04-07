using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        private readonly IMapper _mapper;

        public AuctionDeletedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("--> Consuming, auction deleted");

            var item = _mapper.Map<Item>(context.Message);

            await item.DeleteAsync();
        }
    }
}
