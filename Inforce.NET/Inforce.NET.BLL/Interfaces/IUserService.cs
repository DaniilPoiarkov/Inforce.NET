using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int id);
        Task<List<ShortedUrlDto>> GetUrlsByUserId(int userId);
        Task<ShortedUrlDto> CreateShortedUrl(NewUrl model);
        Task<ShortedUrlDto> GetLinkByTinyUrl(string tinyUrl);
        Task<ShortedUrlDto> GetUrlById(int id);
        Task DeleteLink(int id);
    }
}
