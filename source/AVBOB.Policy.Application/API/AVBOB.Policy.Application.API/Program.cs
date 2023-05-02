using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using AVBOB.Application.Entities.Context;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
});

builder.Services.AddDbContext<AVBOBPolicyApplicationContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionString:DataStore"]);
});

builder.Services.AddTransient<IBLLPolicy, BLLPolicy>();
builder.Services.AddTransient<IBLLLookups, BLLLookups>();
builder.Services.AddTransient<IBLLPolicyHolder, BLLPolicyHolder>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Documents")),
    RequestPath = "/Documents"
});

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
