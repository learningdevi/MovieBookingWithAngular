using AutoMapper;
using Microsoft.Core.Repository.Models;
using Microsoft.MovieBooking.Models;
using System.Runtime.CompilerServices;

namespace Microsoft.MovieBooking
{
    public static class MappingProfile 
    {
        public static void AutoMap(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, Customer>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
