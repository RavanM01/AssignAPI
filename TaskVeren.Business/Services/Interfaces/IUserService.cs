using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.User;

namespace TaskVeren.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterDto Dto);
        Task<string> Login(LoginDto Dto);
    }
}
