using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeleperformanceProject.ShoppingList.Application.Repositories;
using TeleperformanceProject.ShoppingList.Application.Repositories.Categories;
using TeleperformanceProject.ShoppingList.Application.Repositories.Products;
using TeleperformanceProject.ShoppingList.Application.Repositories.RabbitMq;
using TeleperformanceProject.ShoppingList.Application.Repositories.ShopLists;
using TeleperformanceProject.ShoppingList.Application.Tokens;
using TeleperformanceProject.ShoppingList.Domain.Entities;
using TeleperformanceProject.ShoppingList.Domain.Entities.Identity;
using TeleperformanceProject.ShoppingList.Persistence.Contexts;

using TeleperformanceProject.ShoppingList.Persistence.Repositories;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.RabbitMq;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.ReadRepositories.Categories;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.ReadRepositories.Products;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.ReadRepositories.ShopLists;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.ReadRepositories.WriteRepositories.ShopLists;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.WriteRepositories.Categories;
using TeleperformanceProject.ShoppingList.Persistence.Repositories.WriteRepositories.Products;

namespace TeleperformanceProject.ShoppingList.Persistence
{
    public static class Configurations
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreDef");
            services.AddDbContext<ShoppingListDbContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentity<User, Roles>().AddEntityFrameworkStores<ShoppingListDbContext>();
            
            services.AddScoped<IProductWriteRepository, ProductsWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IListsWriteRepository, ShopListsWriteRepository>();
            services.AddScoped<IListsReadRepository, ShopListsReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<HttpContextAccessor>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IRabbitMqConnection, RabbitMqConnection>();
            return services;

            
        }
    }
}



  