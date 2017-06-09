using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PalugaApi.Models;
using ServiceLayer.DTO;

namespace PalugaApi.Mappers
{
    public class WishlistMapper : Profile
    {
        public WishlistMapper()
        {
            CreateMap<AddWishlistRequest, AddWishlistDto>();
        }
    }
}
