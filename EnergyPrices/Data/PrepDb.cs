using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EnergyPrices.Models;
using System;
using System.Linq;
using EnergyPrices.Data;
using EnergyPrices.SyncService;
using AutoMapper;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd, IMapper mapper)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<IEnergyPriceRepo>(), isProd, mapper);
            }
        }

        private static void SeedData(IEnergyPriceRepo context, bool isProd, IMapper mapper)
        {

         

            if (!context.GetAllEnergyPrices().Any())
            {
                Console.WriteLine("--> Seeding data...");
                new EnergyPriceSync().MakeRequest(mapper, context, 0);
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }


    }
}
