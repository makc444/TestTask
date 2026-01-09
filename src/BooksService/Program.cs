using BooksService;
using BooksService.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<BooksContext>();

builder.Services.AddScoped<GetBookHandler>();
builder.Services.AddScoped<DeleteBookHandler>();
builder.Services.AddScoped<PutBookHandler>();
builder.Services.AddScoped<CreateBookHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development env");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();