using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DatabaseLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer.Mappers
{
    public class WishlistMapper : Profile
    {
        public WishlistMapper()
        {
            CreateMap<Wishlist, WishlistDto>();
        }
    }
}
