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

namespace EnergyPrices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyPricesController : Controller
    {
        private readonly EnergyPricesContext _context;
        private readonly IMapper _mapper;

        public EnergyPricesController(EnergyPricesContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EnergyPriceReadDTO>> GetEnergyPrices()
        {
            IEnumerable<EnergyPrice> energyPrices = new List<EnergyPrice>();
            energyPrices.Append(new EnergyPrice());
            return Ok(_mapper.Map<IEnumerable<EnergyPriceReadDTO>>(energyPrices));
        }
    }
}
