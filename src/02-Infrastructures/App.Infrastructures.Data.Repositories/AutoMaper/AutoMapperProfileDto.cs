using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.BidDtoModels;
using App.Domain.Core.DtoModels.BuyerDtoModels;
using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.DtoModels.CommentDtoModels;
using App.Domain.Core.DtoModels.ImageDtoModels;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
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
            CreateMap<Auction, AuctionDtoOutput>();
            CreateMap<Bid, BidDto>();
            CreateMap<Buyer, BuyerDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.StallId, opt => opt.Ignore());
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<Seller, CreateSellerDto>().ReverseMap();
            CreateMap<Seller, SellerOutputDto>().ReverseMap();
            CreateMap<Seller, UpdateSellerDto>().ReverseMap();
            CreateMap<Stall,StallDto>().ReverseMap();
            CreateMap<Stall, CreateStallDto>().ReverseMap();
            CreateMap<Stall, UpdateStallDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();

        }
    }
}
