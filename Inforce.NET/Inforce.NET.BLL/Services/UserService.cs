using AutoMapper;
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
    public class UserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = _mapper.Map<UserDto>(
                await _dbContext.Users
                    .Where(u => u.Id == id)
                    .Include(u => u.OwnedUrls)
                    .FirstOrDefaultAsync());

            if(user == null)
                throw new NotFoundException(nameof(User));

            return user;
        }

        public async Task<List<ShortedUrlDto>> GetUrlsByUserId(int userId)
        {
            return _mapper.Map<List<ShortedUrlDto>>(await _dbContext.ShortedUrls.Where(su => su.CreatedById == userId).ToListAsync());
        }
    }
}
