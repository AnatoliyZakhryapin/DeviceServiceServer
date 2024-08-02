using System.Net.Http.Headers;
using System.Net.Sockets;

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

            try
            {
                // Costruisce l'URL in base al comando ricevuto
                var response = await _httpClient.GetAsync($"https://localhost:5000/{command}");

                // Verifica se la risposta è avvenuta con successo
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Controlla se l'errore è dovuto a connessione rifiutata
                if (ex.InnerException is SocketException socketEx && socketEx.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    return "Errore: impossibile connettersi al DeviceService. Verifica che il servizio sia attivo.";
                }

                // Altri tipi di errori di richiesta HTTP
                return $"Errore nella comunicazione con il DeviceService: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Gestisce eventuali altre eccezioni
                return $"Errore generale: {ex.Message}";
            }
        }
    }
}
