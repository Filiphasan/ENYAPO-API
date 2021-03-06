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
    public class UserPostService : IUserPostService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserPost> _userPostRepository;
        public UserPostService(IUnitOfWork unitOfWork, IGenericRepository<UserPost> userPostRepository, UserManager<UserApp> userManager)
        {
            _unitOfWork = unitOfWork;
            _userPostRepository = userPostRepository;
            _userManager = userManager;
        }

        public async Task<Response<UserPostDto>> AddAsync(CreateUserPostDto entity)
        {
            entity.CreatedTime = DateTime.Now;
            var newEntity = ObjectMapper.Mapper.Map<UserPost>(entity);
            await _userPostRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<UserPostDto>(newEntity);
            return Response<UserPostDto>.Success(newDto, 200);
        }

        public async Task<Response<IEnumerable<UserPostDto>>> GetAllAsync()
        {
            var entities = await _userPostRepository.GetAllAsync();
            if (!entities.Any())
            {
                return Response<IEnumerable<UserPostDto>>.Fail("No data!", 502, true);
            }
            var entitiesDto = ObjectMapper.Mapper.Map<List<UserPostDto>>(entities);
            foreach (var item in entitiesDto)
            {
                var user = await _userManager.FindByIdAsync(item.UserAppId);
                if (user != null)
                {
                    var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
                    item.UserAppDto = userDto;
                }
            }
            return Response<IEnumerable<UserPostDto>>.Success(entitiesDto,200);
        }

        public async Task<Response<UserPostDto>> GetByIdAsync(int id)
        {
            var entity = await _userPostRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<UserPostDto>.Fail("User Post not found!", 404, true);
            }
            var entityDto = ObjectMapper.Mapper.Map<UserPostDto>(entity);
            var user = await _userManager.FindByIdAsync(entityDto.UserAppId);
            var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
            entityDto.UserAppDto = userDto;
            return Response<UserPostDto>.Success(entityDto,200);
        }

        public async Task<Response<NoDataDto>> HardRemove(int id)
        {
            var existEntity = await _userPostRepository.GetByIdAsync(id);
            if (existEntity == null)
            {
                return Response<NoDataDto>.Fail("User Post not found!",404,true);
            }
            _userPostRepository.Remove(existEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> IncrementLike(int id)
        {
            var entity = await _userPostRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Fail("Gönderi bulunamadı!", 404, true);
            }
            entity.LikesCount += 1;
            _userPostRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var entity = await _userPostRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Fail("User Post is not found!", 404, true);
            }
            entity.IsDelete = true;
            _userPostRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<UserPostDto>> Update(UpdateUserPostDto entity)
        {
            var existEntity = await _userPostRepository.GetByIdAsync(entity.Id);
            if (existEntity == null)
            {
                return Response<UserPostDto>.Fail("User Post not found!", 404, true);
            }
            var updatedEntity = ObjectMapper.Mapper.Map<UserPost>(entity);
            updatedEntity.ModifiedTime = DateTime.Now;
            var newEntity = _userPostRepository.Update(updatedEntity);
            await _unitOfWork.CommitAsync();
            return Response<UserPostDto>.Success(200);
        }

        public async Task<Response<IEnumerable<UserPostDto>>> Where(Expression<Func<UserPost, bool>> predicate)
        {
            var list = await _userPostRepository.Where(predicate).OrderByDescending(x => x.Id).ToListAsync();
            if (!list.Any())
            {
                return Response<IEnumerable<UserPostDto>>.Fail("No data!", 502, true);
            }
            var listDto = ObjectMapper.Mapper.Map<List<UserPostDto>>(list);
            foreach (var item in listDto)
            {
                var user = await _userManager.FindByIdAsync(item.UserAppId);
                if (user != null)
                {
                    var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
                    item.UserAppDto = userDto;
                }
            }
            return Response<IEnumerable<UserPostDto>>.Success(listDto, 200);
        }

        public async Task<Response<IEnumerable<UserPostDto>>> WhereMany(params Expression<Func<UserPost, bool>>[] predicates)
        {
            var list = await _userPostRepository.WhereMany(predicates).OrderByDescending(x => x.Id).ToListAsync();
            if (!list.Any())
            {
                return Response<IEnumerable<UserPostDto>>.Fail("No data!", 502, true);
            }
            var listDto = ObjectMapper.Mapper.Map<List<UserPostDto>>(list);
            foreach (var item in listDto)
            {
                var user = await _userManager.FindByIdAsync(item.UserAppId);
                if (user != null)
                {
                    var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
                    item.UserAppDto = userDto;
                }
            }
            return Response<IEnumerable<UserPostDto>>.Success(listDto, 200);
        }
    }
}
