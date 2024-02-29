using Ej2RickMortyAPI.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2RickMortyAPI.Services
{
    public class RickMortyAPI
    {
        HttpClient _httpClient;
        string _url = "https://rickandmortyapi.com/api/";
        public async Task<List<Character>> GetCharacters()
        {
            _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync($"{_url}character");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var charactersData = JsonConvert.DeserializeObject<CharactersData>(json);

            // Si prefieres trabajar con la lista de objetos Character directamente, puedes devolverla así
            return charactersData.Results.Select(result => new Character
            {
                Id = result.Id,
                Name = result.Name,
                Species = result.Species,
                Status = result.Status,
                Image = result.Image,
                // Otros campos que necesites asignar
            }).ToList();
        }
        public async Task<Character> GetCharacter(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}character/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var charactersData = JsonConvert.DeserializeObject<Character>(json);
            return charactersData;
        }
    }
}
