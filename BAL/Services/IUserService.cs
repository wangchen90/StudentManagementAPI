using BAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IUserService
    {
       
        Task<bool> UserRegistration(UserLoginModel login);
        Task<bool> UserLoginInfo(UserLoginModel login);
        
    }

}
