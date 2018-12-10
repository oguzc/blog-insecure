using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Blog.Api.Services;

namespace Blog.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddScoped<IBlogPostRepository>(c => new BlogPostRepository(Configuration["ConnectionString"]));

            var builder = new ContainerBuilder();
            //var appSettings = Configuration.GetSection("ApiSettings").Get<AppSettings>();
            //builder.RegisterInstance(appSettings);

            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
