using System.Net.Http.Headers;

namespace DeviceServiceServer.Data
{
    public class RemoteDeviceServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly JwtTokenService _jwtTokenService;

        public RemoteDeviceServiceClient(HttpClient httpClient, JwtTokenService jwtTokenService)
        {
            _httpClient = httpClient;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> SendCommand(string command)
        {
            var token = _jwtTokenService.GenerateToken(); // Genera il token JWT
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Costruisce l'URL in base al comando specifico
            var response = await _httpClient.GetAsync($"https://localhost:5000/{command}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Errore: {response.StatusCode}";
            }
        }
    }
}
