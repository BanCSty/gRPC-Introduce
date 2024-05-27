﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using gRPC.Application.Common.Behaviors;

namespace gRPC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //регистрирует MediatR в контейнере зависимостей и настраивает все необходимые типы,
            //связанные с медиатором, включая обработчики запросов и команд
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                //добавляет валидаторы в контейнер зависимостей
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            //регистрирует ValidationBehavior<,> как общее поведение для всех типов запросов и команд, реализующих интерфейс
            //IPipelineBehavior<,>. Это поведение будет применять валидацию к запросам и командам перед их выполнением
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
