using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entities.Interfaces;
using Chat.Repositories.EFCore.DataContext;
using Chat.Repositories.EFCore.Repositories;
using Chat.UseCases.Common.Behaviors;
using Chat.UseCases.CreateMessage;
using Chat.UseCases.CreateUser;
using Chat.UseCases.Login;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Chat.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddChatServices(this IServiceCollection services,  
            IConfiguration configuration
            )
        {
            services.AddDbContext<ChatContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ChatDB"))
            );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // user 
            services.AddMediatR(typeof(CreateUserInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateUserValidator).Assembly);
            // message
            services.AddMediatR(typeof(CreateMessageInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateMessageValidator).Assembly);
            // login
            /*services.AddMediatR(typeof(LoginInteractor));
            services.AddValidatorsFromAssembly(typeof(LoginValidator).Assembly);*/
            //#
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
