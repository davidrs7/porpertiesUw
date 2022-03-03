using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using properties.core.interfaces;
using properties.core.services;
using properties.infraestructure.Data;
using properties.infraestructure.filtres;
using properties.core.DTO;
using properties.infraestructure.repositories;
using properties.infraestructure.Services;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace properties.api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            // definición de dependencias 
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();
            services.AddSingleton<IUriService>(provider => {
                var Accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var Request = Accesor.HttpContext.Request;
                var absoulteUri = string.Concat(Request.Scheme, "://",Request.Host.ToUriComponent());
                return new UriService(absoulteUri);
            });
            services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));

            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            services.AddDbContext<propertiesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("properties")));
            services.AddSwaggerGen(doc => {
                doc.SwaggerDoc("v1", new OpenApiInfo
                {Title = "Properties" , Version = "v1"});
                var xlmFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xlmFile);
                doc.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:secretKey"]))
                };
            });

            services.AddMvc(options => 
            {
                options.Filters.Add<validationFilter>();
            }).AddFluentValidation(options => 
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            }) ;      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","Properties");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
