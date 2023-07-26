

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerGen(); 
builder.Services.AddServerSideBlazor(); 
builder.Services.AddScoped<ToDoAppService>(); 
builder.Services.AddSqlite<AppContext>(@"Data Source=TodoListApp.db"); 

var app = builder.Build(); 
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
    
app.MapHub<HubConnection>("/HubServer"); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


