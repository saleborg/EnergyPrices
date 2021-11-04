using EnergyPrices.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace EnergyPrices.SyncService
{

    public class EnergyPriceSync
    {
        string url = "https://ei.entryscape.net/rowstore/dataset/";
        string urlParameters = "8db5a77c-ef90-49f0-8e2f-18327735c463? _limit = 100 & _offset = 0";
        

        public List<EnergyPriceCreateDTO> MakeRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var energyPrices = new List<EnergyPriceCreateDTO>();
             client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<Root>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    foreach (var price in dataObjects.results)
                    {

                        energyPrices.Add(new EnergyPriceCreateDTO()
                        {
                            BidArea = price.bid_area,
                            Contract = price.contract,
                            ContractName = price.contract_name,
                            Supplier = price.supplier,
                            Date = price.date,
                            PriceOrePerKwh = price.price_ore_per_kwh
                        });
                    }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
            return energyPrices;
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
