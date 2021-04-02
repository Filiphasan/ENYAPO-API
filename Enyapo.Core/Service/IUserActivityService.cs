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
    public interface IUserActivityService
    {
        Task<Response<UserActivityDto>> AddAsync(CreateUserActivityDto entity);
        Task<Response<IEnumerable<UserActivityDto>>> Where(Expression<Func<UserActivity, bool>> predicate);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> HardRemove(int id);
    }
}
