using Enyapo.Core.Repository;
using Enyapo.Core.Service;
using Enyapo.Core.UnitOfWork;
using Enyapo.Data.Context;
using Enyapo.Data.Repository;
using Enyapo.Data.UnitOfWork;
using Enyapo.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        //public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        //{
        //    //serviceCollection.AddScoped<IAuthService, AuthService>();
        //    //serviceCollection.AddScoped<IUserService, UserService>();
        //    //serviceCollection.AddScoped<ITokenService, TokenService>();
        //    //serviceCollection.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        //    //serviceCollection.AddScoped(typeof(IGenericService<,>),typeof(GenericService<,>));
        //    //serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        //    return serviceCollection;
        //}
    }
}
