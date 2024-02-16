using Elasticsearch.Net;
using Nest;
using ElasticsearchApi.Models;
using ElasticsearchApi.Services;
using ElasticsearchApi.Services.Aggregation;
using ElasticsearchApi.Services.CRUD;
using ElasticsearchApi.Services.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var cloudId = "firstElasticsearchDep:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvOjQ0MyQxOWM0NDIzZjBiMzk0NjYyOTk1MTJjZGEzMGFlYjAyYyRlYjlhZjU5MTBiYjQ0NjUzYjk3YmRmZDNkZGJhYmVjOA==";
var credentials = new BasicAuthenticationCredentials("elastic", "VGs3SlNJc1r2Y1HBbFsBAxot");
var pool = new CloudConnectionPool(cloudId, credentials);
var settings = new ConnectionSettings(pool).DefaultIndex("orders")
    .ThrowExceptions()
    .EnableDebugMode();

var client = new ElasticClient(settings);

builder.Services.AddSingleton(client);
builder.Services.AddScoped<IElasticsearchCrudService, ElasticsearchCrudService>();
// builder.Services.AddScoped<IElasticsearchQueryService<Order>, OrderQueryService>();
// builder.Services.AddScoped<IElasticsearchAggregationService, OrderAggregationService>();

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