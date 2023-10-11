using MultipleImplementationsDependencyInjection.ServiceManager;
using MultipleImplementationsDependencyInjection.Services;

namespace MultipleImplementationsDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddScoped<IMyService, MyServiceA>();
            builder.Services.AddScoped<IMyServiceManager, MyServiceManager>();

            builder.Services.AddSingleton<SmsReminderService>();
            builder.Services.AddSingleton<EmailReminderService>();
            builder.Services.AddSingleton<PushNotificationReminderService>();
            // Use Delegate Factories to resolve the correct service
            builder.Services.AddScoped<IReminderServiceResolver>(serviceProvider => serviceType =>
            {
                return serviceType switch
                {
                    ServiceType.Email => serviceProvider.GetRequiredService<EmailReminderService>(),
                    ServiceType.Sms => serviceProvider.GetRequiredService<SmsReminderService>(),
                    ServiceType.Push => serviceProvider.GetRequiredService<PushNotificationReminderService>(),
                    _ => throw new InvalidOperationException(), // or maybe return null, up to you
                };
            });
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