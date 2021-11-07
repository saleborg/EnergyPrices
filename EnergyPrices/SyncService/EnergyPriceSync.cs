using AutoMapper;
using EnergyPrices.Data;
using EnergyPrices.Dtos;
using EnergyPrices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


namespace EnergyPrices.SyncService
{

    public class EnergyPriceSync
    {
        string url = "https://ei.entryscape.net/rowstore/dataset/";
        string urlParameters = "8db5a77c-ef90-49f0-8e2f-18327735c463? _limit = 100 & _offset=30000 ";
       


        public void MakeRequest(IMapper _mapper, IEnergyPriceRepo repo)
        {
            IList<EnergyPriceCreateDTO> energyPrices = new List<EnergyPriceCreateDTO>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                Root root = getDataFromCall(_mapper, repo, response);
                while (root.next != null)
                {
                    response = client.GetAsync(root.next).Result;
                    root = getDataFromCall(_mapper, repo, response);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();

            
        }

        private static Root getDataFromCall(IMapper _mapper, IEnergyPriceRepo repo, HttpResponseMessage response)
        {
            var root = response.Content.ReadAsAsync<Root>().Result;
            foreach (var price in root.results)
            {
                EnergyPriceCreateDTO energyPriceCreateDTO = new EnergyPriceCreateDTO()
                {
                    BidArea = price.bid_area,
                    Contract = price.contract,
                    ContractName = price.contract_name,
                    Supplier = price.supplier,
                    Date = price.date,
                    PriceOrePerKwh = price.price_ore_per_kwh
                };
                var energyPrice = _mapper.Map<EnergyPrice>(energyPriceCreateDTO);
                repo.CreateEnergyPrice(energyPrice);
                repo.SaveChange();
            }

            return root;
        }
    }


    public class Result
    {
        public string date { get; set; }
        public string bid_area { get; set; }
        public string contract { get; set; }
        public string supplier { get; set; }
        public string contract_name { get; set; }
        public string price_ore_per_kwh { get; set; }
    }

    public class Root
    {
        public string next { get; set; }
        public int resultCount { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int queryTime { get; set; }
        public List<Result> results { get; set; }
    }




}
