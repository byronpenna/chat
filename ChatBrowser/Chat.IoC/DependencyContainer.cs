﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entities.Interfaces;
using Chat.Repositories.EFCore.DataContext;
using Chat.Repositories.EFCore.Repositories;
using Chat.UseCases.Common.Behaviors;
using Chat.UseCases.CreateUser;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(typeof(CreateUserInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateUserValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}