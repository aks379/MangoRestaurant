using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto ResponseModel { get; set; }

        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.ResponseModel = new ResponseDto();
            this.HttpClient = httpClient;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MangoAPI");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiRequest.Url),
                };
                request.Headers.Add("Accept", "application/json");
                if (apiRequest.Data != null) 
                { 
                    request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                switch(apiRequest.APIType)
                {
                    case StaticDetails.APIType.POST:
                        request.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.APIType.PUT:
                        request.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.APIType.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;
                    default:
                        request.Method = HttpMethod.Get;
                        break;
                }

                var apiresponse = await client.SendAsync(request);
                var content = await apiresponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex) 
            {
                var resException = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var resSerialize = JsonConvert.SerializeObject(resException);
                return JsonConvert.DeserializeObject<T>(resSerialize); 
            }
        }
    }
}
