namespace AutoMoreira.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Rafael
            services.AddDbContext<AppDbContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            //Para facilitar a cria��o de password. 
            //Nao Requerer Letras maisculuas, minusculas e numeros
            //Apenas requer uma password de tamanho 6
            services
            .AddIdentityCore<User>(x =>
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
            .AddDefaultTokenProviders();
            //Se nao adicionar o Defaul Token, o no UserService, ele n�o faz o Generate/reset token

            //Portador do JWT
            //Cada vez que criptografamos com uma chave, tambem temos de discriptografar com a mesma
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });

            //Rafael
            //Indica que estou a trabalhar com a arquitetura MVC com Views Controllers. Permite chamar o meu controller
            //NewsoftJson para evitar um loop infinito no retorno
            //AddJsonOptions para os Enums, onde para cada item do meu Enum, retorna um Id
            services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            //Repositories
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            //Services
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();

            //Rafael AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Rafael - JWT
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoMoreira.API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header utilizando o Bearer.
                                Entre com 'Bearer ' [espa�o] ent�o coloque o seu token.
                                Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoMoreira.API v1"));

            }

            app.UseHttpsRedirection(); //Rafael - HTTPS

            app.UseRouting();  // Indica que vou trabalhar por rotas. 

            //Auth- 1� autentica e depois autoriza
            app.UseAuthentication();

            app.UseAuthorization();

            //Rafael - Upload de ficheiros
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")

            });

            //Rafael - Dado qualquer header da requisi��o por http vinda de qualquer metodo (get, post, delete..) e vindos de qualquer origem
            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            //E vou retornar determinados endpoints de acordo com a configura��o destas rotas dentro do meu controller
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}