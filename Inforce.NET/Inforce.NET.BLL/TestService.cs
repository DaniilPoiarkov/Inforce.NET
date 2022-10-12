using AutoMapper;
using Inforce.NET.Common.DTOs;
using Inforce.NET.Common.Enums;
using Inforce.NET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.BLL
{
    public class TestService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public TestService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDto GetTestSingle()
        {
            return _mapper.Map<UserDto>(_dbContext.Users.First());
        }

        public List<UserDto> GetTestPlural()
        {
            return _mapper.Map<List<UserDto>>(_dbContext.Users);
        }
    }
}
