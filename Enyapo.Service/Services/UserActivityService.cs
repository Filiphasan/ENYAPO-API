using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using Enyapo.Core.Repository;
using Enyapo.Core.Service;
using Enyapo.Core.UnitOfWork;
using Enyapo.Service.Mapper;
using Enyapo.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Service.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IGenericRepository<UserActivity> _userActivityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserActivityService(IGenericRepository<UserActivity> userActivityRepository, IUnitOfWork unitOfWork)
        {
            _userActivityRepository = userActivityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<UserActivityDto>> AddAsync(CreateUserActivityDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<UserActivity>(entity);
            newEntity.CreatedTime = DateTime.Now;
            await _userActivityRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<UserActivityDto>(newEntity);
            return Response<UserActivityDto>.Success(newDto, 200);
        }

        public async Task<Response<NoDataDto>> HardRemove(int id)
        {
            var entity = await _userActivityRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Fail("User Activity not found!", 404, true);
            }
            _userActivityRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var entity = await _userActivityRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Fail("User Activity not found!", 404, true);
            }
            entity.IsDelete = true;
            entity.ModifiedTime = DateTime.Now;
            _userActivityRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<IEnumerable<UserActivityDto>>> Where(Expression<Func<UserActivity, bool>> predicate)
        {
            var list = await _userActivityRepository.Where(predicate).ToListAsync();
            if (!list.Any())
            {
                return Response<IEnumerable<UserActivityDto>>.Fail("No data!", 502, true);
            }
            var listDto = ObjectMapper.Mapper.Map<List<UserActivityDto>>(list);
            return Response<IEnumerable<UserActivityDto>>.Success(listDto, 200);
        }
    }
}
