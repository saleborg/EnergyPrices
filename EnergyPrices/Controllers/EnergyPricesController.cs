using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnergyPrices.Data;
using EnergyPrices.Models;
using AutoMapper;
using EnergyPrices.Dtos;
using EnergyPrices.SyncService;

namespace EnergyPrices.Controllers
{
    [Route("api/EnergyPrices")]
    [ApiController]
    public class EnergyPricesController : Controller
    {
        private readonly IEnergyPriceRepo repo;
        private readonly IMapper _mapper;

        public EnergyPricesController(IEnergyPriceRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this._mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EnergyPriceReadDTO>> GetEnergyPrices()
        {

            EnergyPriceSync sync = new EnergyPriceSync();
            var respons = sync.MakeRequest(_mapper, repo, 0);
            return Ok(repo.GetAllEnergyPrices());
        }
    }
}
