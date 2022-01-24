using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using GetirBank.Authentication;
using GetirBank.Database;
using GetirBank.Database.Repositories;
using GetirBank.Database.Repositories.Implementations;
using GetirBank.Dto;
using GetirBank.Services;
using GetirBank.Services.Implementations;
using GetirBank.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GetirBank
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .AddJsonFile("src/appsettings.json", false, true);
            this.Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddAuthorization();
            services.AddControllers(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<BankContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("db")));
            services.AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<Startup>(); });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IAuthentication, Authentication.Authentication>();

            services.AddTransient<IValidator<CreateCustomerDTO>, CreateCustomerDtoValidator>();

            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}