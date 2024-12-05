using System;

namespace WebMexiFly.Utils;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: Obtiene datos de la API
    public async Task<ResponseGeneral<T?>> GetAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseGeneral<T>>();
            }

            return new ResponseGeneral<T?>() 
            {
                Status = "Error"
            };
        }
        catch (System.Exception ex)
        {

            return new ResponseGeneral<T?>() 
            {
                Status = "Error"
            };
        }

    }

    // POST: Envía datos para crear un recurso
public async Task<ResponseGeneral<T?>> PostAsync<T, R>(string url, R data)
{
    try
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(url, jsonContent);

        if (response.IsSuccessStatusCode)
        {
            // Deserializamos la respuesta en ResponseGeneral<T>
            return await response.Content.ReadFromJsonAsync<ResponseGeneral<T?>>();
        }

        return new ResponseGeneral<T?>()
        {
            Status = "Error"
        };
    }
    catch (System.Exception ex)
    {
        // En caso de un error, devolvemos un objeto con error
        return new ResponseGeneral<T?>()
        {
            Status = "Error"
        };
    }
}


    // PUT: Actualiza completamente un recurso
    public async Task<bool> PutAsync<T>(string url, T data)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PutAsync(url, jsonContent);
        return response.IsSuccessStatusCode;
    }

    // PATCH: Actualiza parcialmente un recurso
    public async Task<bool> PatchAsync<T>(string url, T data)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");

        var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = jsonContent };
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    // DELETE: Elimina un recurso
    public async Task<bool> DeleteAsync(string url)
    {
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}

