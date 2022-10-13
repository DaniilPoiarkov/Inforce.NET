using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> Login(UserLogin credentials);
    }
}
