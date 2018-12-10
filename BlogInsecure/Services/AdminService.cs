using System.Threading.Tasks;
using BlogInsecure.Client;
using BlogInsecure.Config;
using BlogInsecure.Models;
using Newtonsoft.Json;

namespace BlogInsecure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IHttpClient _apiClient;
        private readonly AppSettings _appSettings;
        private const string BasePath = "Users";

        public AdminService(
            IHttpClient httpClient,
            AppSettings appSettings)
        {
            _apiClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<AuthenticationDto> Authenticate(UserDto userDto)
        {
            var requestMessage =_apiClient.CreatePostRequest($"{_appSettings.AdminApiUrl}{BasePath}/Authenticate", userDto);
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
            var authenticationDto = JsonConvert.DeserializeObject<AuthenticationDto>(responseBody);
            return authenticationDto;
        }

        public async Task Register(UserDto userDto)
        {
            var requestMessage = _apiClient.CreatePostRequest($"{_appSettings.AdminApiUrl}{BasePath}/Register", userDto);
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> CanCreatePost(string token)
        {
            var requestMessage = _apiClient.CreateGetRequest($"{_appSettings.AdminApiUrl}{BasePath}/CanCreatePost");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
            return true;
        }
    }
}
