using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.AccountDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.CommentDtoModels;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.DtoModels.BuyerDtoModels;
using App.Domain.Core.DtoModels.BidDtoModels;

namespace App.EndPoints.MVC.OnlineMarket.Models.AutoMapperViewModels
{
    public class AutoMapperProfileVM : Profile
    {
        public AutoMapperProfileVM()
        {
            CreateMap<LoginViewModel, LoginUserDto>();
            CreateMap<RegisterViewModel, RegisterUserDto>();
            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            CreateMap<UpdateProductVM, UpdateProductDto>().ReverseMap();
            CreateMap<StallListViewModel, StallDto>().ReverseMap();
            CreateMap<UpdateStallViewModels, UpdateStallDto>().ReverseMap();
            CreateMap<UserViewModels, UserDto>().ReverseMap();
            CreateMap<CreateStallViewModel, CreateStallDto>().ReverseMap();
            CreateMap<CommentViewModel, CommentDto>().ReverseMap();
            CreateMap<InvoiceViewModel, InvoiceDto>().ReverseMap();
            CreateMap<CreateProductViewModel, CreateProductDto>().ReverseMap();
            CreateMap<CreateAuctionViewModel, AuctionDtoCreate>().ReverseMap();
            CreateMap<AuctionViewModel, AuctionDtoOutput>().ReverseMap();
            CreateMap<SellerViewmodel, SellerDto>().ReverseMap();
            CreateMap<UpdateSellerViewModel, SellerDto>().ReverseMap();
            CreateMap<BuyerViewModel, BuyerDto>().ReverseMap();
            CreateMap<UpdateCustomerViewModel, BuyerDto>().ReverseMap();
            CreateMap<HomeAuctionViewModel, AuctionDto>().ReverseMap();
            CreateMap<BidViewModel, CreateBidDto>().ReverseMap();
        }
    }
}
