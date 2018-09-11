using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Application.Services.ApplicationService;
using Easv.PetShop.Core.Application.Services.ApplicationService.Services;
using Easv.PetShop.Infrastructure.Static.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EASV.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var petService = serviceProvider.GetService<IPetService>();

            var printer = new Printer(petService);
        }
    }
}
