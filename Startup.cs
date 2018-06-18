﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcPolishNotation.Interfaces;
using CalcPolishNotation.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CalcPolishNotation
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
          builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
        }));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddSingleton<IPostfixNotationExpressionRepository, PostfixNotationExpressionRepository>();
      services.Configure<MvcOptions>(options =>
      {
        options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }
      app.UseCors("MyPolicy");
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
