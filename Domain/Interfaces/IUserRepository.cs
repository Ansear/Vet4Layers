using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByRefreshTokenAsync(string username);
}