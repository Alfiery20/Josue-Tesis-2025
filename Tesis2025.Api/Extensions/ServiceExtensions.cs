﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tesis2025.Api.Utils;
using Tesis2025.Application.Common.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FluentValidation.AspNetCore;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common;
using Tesis2025.Persistence;
using Tesis2025.Infrastructure;

namespace Tesis2025.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>();
            var jwtSettings = configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = appSettings.ApplicationName,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5) // Ajuste de tolerancia
                };
                config.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken is JwtSecurityToken accessToken)
                        {
                            if (context.Principal.Identity is ClaimsIdentity identity)
                            {
                                // Reclamo opcional
                                identity.AddClaim(new Claim("access_token", accessToken.RawData));
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }

        public static IServiceCollection AddCustomAuthentication_old(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>();
            var jwtSettings = configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    RequireSignedTokens = true,
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = appSettings.ApplicationName,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                };
                config.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken is JwtSecurityToken accessToken)
                        {
                            if (context.Principal.Identity is ClaimsIdentity identity)
                            {
                                identity.AddClaim(new Claim("access_token", accessToken.RawData));
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(c =>
            {
                c.AddPolicy(Constants.GlobalOAuthPolicyName, p =>
                {
                    p.RequireAuthenticatedUser();
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomMVC(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter(Constants.GlobalOAuthPolicyName));
            }).AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddPolicy(Constants.CorsPolicyName,
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddHttpContextAccessor();
            services.AddResponseCompression();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            var appSettings = configuration.Get<AppSettings>();

            services.AddSingleton(x => new AppSettings
            {
                ApplicationName = appSettings.ApplicationName,
                ApplicationDisplayName = appSettings.ApplicationDisplayName,
                ApplicationId = appSettings.ApplicationId,
                LongRequestTimeMilliseconds = appSettings.LongRequestTimeMilliseconds,
                SlidingExpirationCacheTimeSeconds = appSettings.SlidingExpirationCacheTimeSeconds,
                GeneralErrorMessage = appSettings.GeneralErrorMessage
            });

            //services.Configure<ExternalServicesSettings>(configuration);
            services.Configure<JwtSettings>(configuration.GetSection(Constants.JwtSettings));
            //var rabbitMQSettings = configuration.GetSection(Constants.RabbitMQSettings).Get<RabbitMQSettings>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IServiceCollection AddLayersDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.ConnectionString);
            services.AddApplicationLayer();
            services.AddPersistenceLayer(connectionString);
            services.AddInfrastructureLayer();
            return services;
        }
    }
}
