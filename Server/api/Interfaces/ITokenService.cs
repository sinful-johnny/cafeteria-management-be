﻿using api.Models;
using api.Models.AuthModels;
using CafeteriaDB;

namespace api.Interfaces
{
    public interface ITokenService
    {
        //public Task<string> CreateToken(string UserName, List<UserRolesModel> roles);
        public Task<string> CreateToken(string UserName, IList<string> roles);
    }
}
