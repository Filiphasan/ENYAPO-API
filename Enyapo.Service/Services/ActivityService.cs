using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using Enyapo.Core.Repository;
using Enyapo.Core.Service;
using Enyapo.Core.UnitOfWork;
using Enyapo.Service.Mapper;
using Enyapo.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Service.Services
{
    public class ActivityService : IActivityService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IGenericRepository<Activity> _activityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserActivityService _userActivityService;
        public ActivityService(IGenericRepository<Activity> activityRepository, IUnitOfWork unitOfWork, UserManager<UserApp> userManager, IUserActivityService userActivityService)
        {
            _activityRepository = activityRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userActivityService = userActivityService;
        }

        public async Task<Response<ActivityDto>> AddAsync(CreateActivityDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<Activity>(entity);
            newEntity.CreatedTime = DateTime.Now;
            await _activityRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<ActivityDto>(newEntity);
            return Response<ActivityDto>.Success(newDto, 200);
        }

        public async Task<Response<IEnumerable<ActivityDto>>> GetAllAsync()
        {
            var entities = await _activityRepository.GetAllAsync();
            if (!entities.Any())
            {
                return Response<IEnumerable<ActivityDto>>.Fail("No data!", 502, true);
            }
            var entitiesDto = ObjectMapper.Mapper.Map<List<ActivityDto>>(entities);
            foreach (var item in entitiesDto)
            {
                var user = await _userManager.FindByIdAsync(item.UserAppId);
                if (user != null)
                {
                    var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
                    item.UserAppDto = userDto;
                }
            }
            return Response<IEnumerable<ActivityDto>>.Success(entitiesDto, 200);
        }

        public async Task<Response<ActivityDto>> GetByIdAsync(int id)
        {
            var entity = await _activityRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<ActivityDto>.Fail("Id is wrong!", 404, true);
            }
            var entityDto = ObjectMapper.Mapper.Map<ActivityDto>(entity);
            var user = await _userManager.FindByIdAsync(entityDto.UserAppId);
            var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
            entityDto.UserAppDto = userDto;
            var activityUsers = await _userActivityService.Where(x => x.ActivityId == entityDto.Id);
            foreach (var item in activityUsers.Data)
            {
                var userrr = await _userManager.FindByIdAsync(item.UserAppId);
                if (userrr != null)
                {
                    var userrrDto = ObjectMapper.Mapper.Map<UserAppDto>(userrr);
                    entityDto.UserAppDtos.Add(userrrDto);
                }

            }
            return Response<ActivityDto>.Success(entityDto, 200);
        }

        public Task<Response<NoDataDto>> HardRemove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ActivityDto>>> JoinWhere(Expression<Func<Activity, bool>> predicate, params Expression<Func<Activity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var entity = await _activityRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Fail("Id is wrong!", 404, true);
            }
            entity.IsDelete = true;
            _activityRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<ActivityDto>> Update(UpdateActivityDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<Activity>(entity);
            newEntity.ModifiedTime = DateTime.Now;
            _activityRepository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            return Response<ActivityDto>.Success(200);
        }

        public async Task<Response<IEnumerable<ActivityDto>>> Where(Expression<Func<Activity, bool>> predicate)
        {
            var list = await _activityRepository.Where(predicate).OrderByDescending(x => x.Id).ToListAsync();
            if (!list.Any())
            {
                return Response<IEnumerable<ActivityDto>>.Fail("No data!", 502, true);
            }
            var entitiesDto = ObjectMapper.Mapper.Map<List<ActivityDto>>(list);
            foreach (var item in entitiesDto)
            {
                var user = await _userManager.FindByIdAsync(item.UserAppId);
                if (user != null)
                {
                    var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
                    item.UserAppDto = userDto;
                }
            }
            return Response<IEnumerable<ActivityDto>>.Success(entitiesDto, 200);
        }
    }
}
