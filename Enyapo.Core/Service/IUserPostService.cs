using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using Enyapo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Service
{
    public interface IUserPostService
    {
        Task<Response<UserPostDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<UserPostDto>>> GetAllAsync();
        Task<Response<IEnumerable<UserPostDto>>> Where(Expression<Func<UserPost, bool>> predicate);
        Task<Response<UserPostDto>> AddAsync(CreateUserPostDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> HardRemove(int id);
        Task<Response<UserPostDto>> Update(UpdateUserPostDto entity);
    }
}
