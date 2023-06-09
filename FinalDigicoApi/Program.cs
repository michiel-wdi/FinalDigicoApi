using FinalDigicoApi.DBAccess;
using FinalDigicoApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddDbContext<DBAccessor>(options 
            => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
        //just change server to whatever

        builder.Services.AddTransient<DataService>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


}