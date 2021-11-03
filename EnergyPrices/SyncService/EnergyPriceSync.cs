using EnergyPrices.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnergyPrices.SyncService
{
    public class EnergyPriceSync
    {
        private const string URL = "https://ei.entryscape.net/rowstore/";
        private const string urlParameters = "dataset/8db5a77c-ef90-49f0-8e2f-18327735c463?_limit=100&_offset=0";


        public async Task<IEnumerable<EnergyPriceReadDTO>> RetriveDataFromAPIAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var energyPrices = await JsonSerializer.DeserializeAsync
                    <IEnumerable<EnergyPriceReadDTO>>(responseStream);
                return energyPrices;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return null;
        }


    }



}
