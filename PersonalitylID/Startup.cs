using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Services;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PersonalityIdentification.Helpers;

namespace PersonalitylID
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var optionsBuilder = new DbContextOptionsBuilder<MyDataContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PersonalIdConString"));

            using (MyDataContext dbContext
                        = new MyDataContext(optionsBuilder.Options))
            {
                var authAdministrator = dbContext.Administrator.FirstOrDefault(t => t.Role != null);
                // if (authAdministrator == null)
                // {
                //     var administrator = new Administrator()
                //     {
                //         Login = "sadmin",
                //         Name = "admin",
                //         Password = HashHelper.ComputeSha256Hash("1234"),
                //         Role = "SuperAdministrator"
                //     };
                //     dbContext.Add(administrator);
                //     dbContext.SaveChanges();
                // }
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options =>
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddScoped<IEducationalInstitutionService, EducationalInstitutionService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IPupilService, PupilService>();
            services.AddScoped<IPupilParentService, PupilParentService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IMovingPupilService, MovingPupilService>();
            services.AddScoped<IMovingTeacherService, MovingTeacherService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<MyDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonalIdConString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          //  app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();
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
