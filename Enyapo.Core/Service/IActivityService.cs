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
    public interface IActivityService
    {
        Task<Response<ActivityDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<ActivityDto>>> GetAllAsync();
        Task<Response<IEnumerable<ActivityDto>>> Where(Expression<Func<Activity, bool>> predicate);
        Task<Response<ActivityDto>> AddAsync(CreateActivityDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> HardRemove(int id);
        Task<Response<ActivityDto>> Update(UpdateActivityDto entity);
    }
}
