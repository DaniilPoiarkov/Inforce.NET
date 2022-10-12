using AutoMapper;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.AuxiliaryModels.Exceptions;
using Inforce.NET.Common.DTOs;
using Inforce.NET.Common.Entities;
using Inforce.NET.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.BLL.Services
{
    public class AuthService
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
            var user = _mapper.Map<UserDto>(await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Login == credentials.Login && u.Password == credentials.Password));

            //if (user == null)
            //    throw new NotFoundException(nameof(User));

            return user;
        }
    }
}
