using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posts.Replies.Likes.Application.Dtos;

namespace Posts.Replies.Likes.Application.Configurations
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(o =>
            {
                o.AllowNullCollections = true;
                o.AllowNullDestinationValues = true;
                o.AddProfile(new Mapping());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            services.AddMediatR(typeof(ApplicationConfigurationExtensions).Assembly);

            return services;
        }
    }
}