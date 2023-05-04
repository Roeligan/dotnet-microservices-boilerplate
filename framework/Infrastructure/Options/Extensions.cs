﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Framework.Infrastructure.Options;

public static class Extensions
{
    public static T LoadOptions<T>(this IConfiguration configuration, string sectionName) where T : IOptionsRoot
    {
        return configuration.GetSection(sectionName).Get<T>()!;
    }

    public static T BindValidateReturn<T>(this IServiceCollection services, IConfiguration configuration) where T : class, IOptionsRoot
    {
        services.AddOptions<T>()
            .BindConfiguration(typeof(T).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return configuration.LoadOptions<T>(typeof(T).Name);
    }
    public static void BindValidate<T>(this IServiceCollection services, IConfiguration configuration) where T : class, IOptionsRoot
    {
        services.AddOptions<T>()
            .BindConfiguration(typeof(T).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

}
