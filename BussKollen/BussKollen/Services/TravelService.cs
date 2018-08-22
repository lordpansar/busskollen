using BussKollen.Assets;
using BussKollen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BussKollen.Services
{
    public class TravelService
    {
        public void ConstructLocationRequest()
        {
            throw new NotImplementedException();
        }

        public void ConstructTravelRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LocationDTO>> GetLocation(string station)
        {
            var key = Key.LocationKey;
            var path = $"http://api.sl.se/api2/typeahead.json?key={key}&searchstring={station}&stationsonly=true&maxresults=5";

            var response = MakeGetHttpRequest(path);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var locations = JsonConvert.DeserializeObject<LocationResponse>(json);

                    if (locations.StatusCode == 0 && locations.ResponseData.Count > 0)
                    {
                        var locationDTOs = GetDTOs(locations.ResponseData);
                        return locationDTOs;
                    }

                    if (locations.StatusCode == 1008)
                    {
                        return null;
                    }
                }
                catch(Exception e)
                {
                    var error = e;
                }
            }

            return null;
        }

        private HttpResponseMessage MakeGetHttpRequest(string path)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client.GetAsync(path).Result;
        }

        private List<LocationDTO> GetDTOs(List<Location> locationList)
        {
            var dtoList = new List<LocationDTO>();

            foreach (var location in locationList)
            {
                var dto = new LocationDTO { Id = int.Parse(location.SiteId), Name = location.Name };
                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
