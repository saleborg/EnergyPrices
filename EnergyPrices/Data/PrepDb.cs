using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EnergyPrices.Models;
using System;
using System.Linq;
using EnergyPrices.Data;
using EnergyPrices.SyncService;
using AutoMapper;
using EnergyPrices.Dtos;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<IEnergyPriceRepo>(), isProd);
            }
        }

        private static void SeedData(IEnergyPriceRepo context, bool isProd)
        {

         

            if (!context.GetAllEnergyPrices().Any())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EnergyPriceCreateDTO, EnergyPrice>().ForMember(x => x.Id, opt => opt.Ignore()));
                var mapper = new Mapper(config);
                Console.WriteLine("--> Seeding data...");
                new EnergyPriceSync().MakeRequest(mapper ,context);

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }


    }
}
