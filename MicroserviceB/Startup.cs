using MassTransit;
using MicroserviceB.Models;
using MicroserviceB.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB
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
            services.AddScoped<IApiResponseService, GetResponseService>();
            services.AddControllers();
            services.AddSingleton<IUriService>(provider =>
            {
                var absoluteUri = "https://localhost:49183/";
                return new UriService(absoluteUri);
            });

            services.AddMassTransit(config => {

                // declare consumer/receiver
                config.AddConsumer<RecieverMessageService>();

                config.UsingRabbitMq((context, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");

                    //declare queue
                    cfg.ReceiveEndpoint("test-queue", c => {
                        c.ConfigureConsumer<RecieverMessageService>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
