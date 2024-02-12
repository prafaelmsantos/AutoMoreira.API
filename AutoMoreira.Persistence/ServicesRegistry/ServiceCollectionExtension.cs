﻿namespace AutoMoreira.Persistence.ServicesRegistry
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IClientMessageRepository, ClientMessageRepository>();

            //Services
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientMessageService, ClientMessageService>();

            //JWT
            //Para facilitar a criação de password. Nao Requerer Letras maisculuas, minusculas e numeros. Apenas requer uma password de tamanho 6
            services.AddIdentityCore<User>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 6;
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();//Se nao adicionar o Default Token, o no UserService, ele não faz o Generate/reset token

            
            services
            .AddGraphQLServer()
            .AddApolloTracing(HotChocolate.Execution.Options.TracingPreference.Always)
            .AddType<UserType>()
            .AddType<RoleType>()
            .AddType<MarkType>()
            .AddType<ModelType>()
            .AddType<VehicleType>()
            .AddType<ClientMessageType>()
            .AddQueryType<Query>()
            .AddFiltering()
            .AddSorting()
            .SetPagingOptions(new PagingOptions
            {
                MaxPageSize = int.MaxValue,
                IncludeTotalCount = true,
                DefaultPageSize = 10
            })
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

            return services;
        }
    }
}
