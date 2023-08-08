using MultipleImplementationsDependencyInjection.Services;
using MultipleImplementationsDependencyInjection.Services.Common;
using System.Linq.Expressions;

namespace MultipleImplementationsDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddScoped<IMyService, MyServiceA>();
            builder.Services.AddSingleton<IReminderService, SmsReminderService>();
            builder.Services.AddSingleton<IReminderService, PushNotificationReminderService>();
            builder.Services.AddSingleton<IReminderService, EmailReminderService>();
            builder.Services.AddSingleton<ServiceResolver>(serviceProvider => serviceType =>
            {
                switch (serviceType)
                {
                    case ServiceType.Email:
                        return serviceProvider.GetService<EmailReminderService>();
                    case ServiceType.Sms:
                        return serviceProvider.GetService<SmsReminderService>();
                    case ServiceType.Push:
                        return serviceProvider.GetService<PushNotificationReminderService>();
                    default:
                        throw new KeyNotFoundException(); // or maybe return null, up to you
                }
            })
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
}