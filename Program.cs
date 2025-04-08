var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    //app.UseReDoc(options => 
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

List<PersonRecord> people = [
    new ("Renan", "Romig", "renanromig@hotmail.com"),
    new ("Arianne", "Romig", "annesantos.03@hotmail.com"),
    new ("Nicole", "Romig", "nicoleromig@hotmail.com")
    ];

app.MapGet("/person", () => people);
app.MapGet("/person/{id}", (int id) => people[id]);
app.MapPost("/person", (PersonRecord p) => people.Add(p));
app.MapDelete("/person", (int id) => people.RemoveAt(id));

app.Run();

public record PersonRecord(string FirstName, string LastName, string Email);

