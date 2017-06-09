using DatabaseLayer.Models;
using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Converters
{
    public static class UserConverter
    {
        public static UserFlatDto ToFlatDto(User user)
        {
            return new UserFlatDto()
            {
                Id = user.Id,
                Name = user.Name                
            };
        }
    }
}
