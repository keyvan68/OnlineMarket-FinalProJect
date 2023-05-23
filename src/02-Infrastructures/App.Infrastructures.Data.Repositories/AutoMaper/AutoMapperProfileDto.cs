using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.AutoMaper
{
    public class AutoMapperProfileDto : Profile
    {
        public AutoMapperProfileDto()
        {
            CreateMap<CommentDto, Comment>().ReverseMap(); //reverse so the both direction
            CreateMap<Auction, AuctionDto>();
            CreateMap<Bid, BidDto>(); 
            CreateMap<Buyer, BuyerDto>(); 
            CreateMap<Category, CategoryDto>();
            CreateMap<Image, ImageDto>(); 
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<Product, ProductDto>(); 
            CreateMap<Role, RoleDto>(); 
            CreateMap<Seller, SellerDto>(); 
            CreateMap<User, UserDto>(); 
            CreateMap<Stall, StallDto>();
        }
    }
}
