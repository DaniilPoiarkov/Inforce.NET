using AutoMapper;
using Inforce.NET.BLL.Interfaces;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.DTOs;
using Inforce.NET.DAL;
using Microsoft.EntityFrameworkCore;

namespace Inforce.NET.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public AuthService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> Login(UserLogin credentials)
        {
            return _mapper.Map<UserDto>(await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Login == credentials.Login && u.Password == credentials.Password));
        }
    }
}
