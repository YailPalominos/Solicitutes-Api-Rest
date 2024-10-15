using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SolicitudTerremotosUSGS
{
    public class SolicitadorTerremotos
    {
        private static readonly string baseUrl = "https://earthquake.usgs.gov/fdsnws/event/1/query";
        public static async Task<string> RealizarSolicitud()
        {
            string parametros = "?format=geojson&starttime=2024-01-01&endtime=2024-12-31&minmagnitude=5";
            string url = $"{baseUrl}{parametros}";

            try
            {
                List<Terremoto> terremotos = await ObtenerTerremotos(url);
                if (terremotos != null && terremotos.Count > 0)
                {
                    string listaTerremotos = "";

                    int indice = 0;
                    foreach (Terremoto terremoto in terremotos)
                    {
                        indice++;
                        listaTerremotos += $"Magnitud: {terremoto.Magnitude}, Lugar: {terremoto.Place}, Fecha: {terremoto.Time}\n";
                        if (indice==5)
                        {
                            break;
                        }
                    }
                    Console.WriteLine(listaTerremotos);
                    return listaTerremotos;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }

            return "No se encontraron terremotos.";
        }

        // Método para obtener la lista de terremotos
        private static async Task<List<Terremoto>> ObtenerTerremotos(string url)
        {
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    var deserealizador = JsonConvert.DeserializeObject<USGSEarthquakeResponse>(cuerpoRespuesta);
                    return deserealizador.Features?.ConvertAll(f => f.Properties);
                }
                else
                {
                    Console.WriteLine($"Error al realizar la solicitud: {respuesta.StatusCode}");
                    return null;
                }
            }
        }
    }

    public class USGSEarthquakeResponse
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonProperty("properties")]
        public Terremoto Properties { get; set; }
    }

    public class Terremoto
    {
        [JsonProperty("mag")]
        public decimal Magnitude { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
