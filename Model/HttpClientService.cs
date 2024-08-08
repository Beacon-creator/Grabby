using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Maui.Controls;

namespace Grabby_Two.Model
{
    public class HttpClientService
        {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
            {
            _httpClient = httpClient;
            }

        private async Task EnsureTokenAsync()
            {
            var tokenJson = await SecureStorage.GetAsync("auth_token");

            Console.WriteLine($"tokenjson: {tokenJson}");
            if (string.IsNullOrEmpty(tokenJson))
                {
                await Shell.Current.GoToAsync("//LoginPage");
                throw new Exception("You are not authorized.");
                }

            // Directly use the token without parsing it as JSON
            var token = tokenJson;

            //  Console.WriteLine($"token: {token}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
            {
            try
                {
                await EnsureTokenAsync();
                return await _httpClient.PostAsync(requestUri, content);
                }
            catch (HttpRequestException ex)
                {
                   Console.WriteLine($"Network error in PostAsync: {ex.Message}");
                throw new Exception("Network error occurred. Please check your connection and try again.");
                }
            catch (Exception ex)
                {
                  Console.WriteLine($"Error in PostAsync: {ex.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
                }
            }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
            {
            try
                {
                await EnsureTokenAsync();
                return await _httpClient.DeleteAsync(requestUri);
                }
            catch (HttpRequestException ex)
                {
                // Console.WriteLine($"Network error in DeleteAsync: {ex.Message}");
                throw new Exception("Network error occurred. Please check your connection and try again.");
                }
            catch (Exception ex)
                {
                //  Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
                }
            }

        private async Task EnsureParsedTokenAsync()
            {
            var tokenJson = await SecureStorage.GetAsync("auth_token");


            //  Console.WriteLine($"tokenjson: {tokenJson}");
            if (tokenJson == null)
                {
                await Shell.Current.GoToAsync("//LoginPage");
                throw new Exception("You are not authorized.");
                }

            var tokenObj = JObject.Parse(tokenJson);
            // Console.WriteLine($"tokenObj: {tokenObj}");
            var token = tokenObj["token"].ToString();

            //  Console.WriteLine($"token: {token}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

