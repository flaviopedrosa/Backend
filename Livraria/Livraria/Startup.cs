using Livraria.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Livraria
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
            // requires 
            // using RazorPagesMovie.Models;
            // using Microsoft.EntityFrameworkCore;
            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<LivrariaContext>(options =>
                options.UseMySql(connection)
            );
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(options =>
            {
                string basePath = AppContext.BaseDirectory;
                string moduleName = GetType().GetTypeInfo().Module.Name.Replace(".dll", ".xml");
                string filePath = Path.Combine(basePath, moduleName);
                //string readme = File.ReadAllText(Path.Combine(basePath, "README.md"));

                ApiKeyScheme scheme = Configuration.GetSection("ApiKeyScheme").Get<ApiKeyScheme>();
                options.AddSecurityDefinition("Authentication", scheme);

                Info info = Configuration.GetSection("Info").Get<Info>();
               // info.Description = readme;
               // options.SwaggerDoc(info.Version, info);

                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();

                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Trabalho de Arquitetura Backend - Aula 02",
                        Version = "v1",
                        Description = "Implementação de WebApi com documentação em DotNet Core",
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Flávio Pedrosa",
                            Url = "https://github.com/flaviopedrosa"
                        } ,
                        License = new License
                        {
                            Name = "GPL",
                            Url = "https://example.com/license"
                        }
                    });
               // options.OperationFilter<ExamplesOperationFilter>();
            });
        }

         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger( c=>c.PreSerializeFilters.Add((swagger, httpReq)=>swagger.Host = httpReq.Host.Value));

            app.UseStaticFiles();
                
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
