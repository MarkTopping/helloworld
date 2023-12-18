namespace HelloWorld.API
{
    public class Program
    {
        public static void Main(string[] args)
        {    
            // lol comment
                
            Console.WriteLine($"Starting Web App. Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
