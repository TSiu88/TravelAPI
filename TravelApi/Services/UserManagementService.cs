using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelApi.Entities;
using TravelApi.Helpers;

namespace TravelApi.Services
{
   public interface IUserManagementService
    {
        bool IsValidUser(string username, string password);
    }

    public class UserManagementService : IUserManagementService
    {
        public bool IsValidUser(string userName , string password)
        {
            if(userName == "" || userName == null)
            {
                return false;
            }
            return true;
        }
    }
}