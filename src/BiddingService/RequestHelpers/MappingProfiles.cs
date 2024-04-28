using AutoMapper;
using BiddingService.Dtos;
using BiddingService.Models;
using Contracts;

namespace BiddingService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bid, BidDto>().ReverseMap();
        CreateMap<Bid, BidPlaced>().ReverseMap();
    }
}
