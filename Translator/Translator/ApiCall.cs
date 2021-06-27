using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Translator
{
    public static class HttpClientObject
    {
        public static HttpClient client = new HttpClient();
    }
    public class ResponseModel
    {
        public bool Error { get; set; }
        public string ErrorType { get; set; }
        public string translated_text { get; set; }
    }

    public class RequestModel
    {
        public string passw = "password_to_login";
        public string from_text { get; set; }
        public string to_lang { get; set; }

        public RequestModel(string from_text, string to_lang)
        {
            this.from_text = from_text;
            this.to_lang = to_lang;
        }
    }

    public class ApiCall
    {
        public string url = "api_server_url";
        public RequestModel request { get; set; }
        public HttpClient client = HttpClientObject.client;
        public ApiCall(string from_text, string to_lang)
        {
            request = new RequestModel(from_text, to_lang);

        }

        public async Task<ResponseModel> Translate()
        {
            var error_return = new ResponseModel();
            error_return.Error = true;

            var internet_status = Connectivity.NetworkAccess;
            if(internet_status == NetworkAccess.Internet)
            {
                var request_json = JsonConvert.SerializeObject(request);
                var data = new StringContent(request_json, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(url, data);
                    if (response.IsSuccessStatusCode)
                    {
                        string result_string = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseModel>(result_string);
                        return result;
                    }
                    else
                    {
                        error_return.ErrorType = "Unknown error occurred from the server";
                        return error_return;
                    }
                }
                catch
                {
                    error_return.ErrorType = "Error occured while sending a request to the server";
                    return error_return;
                }
            }
            else
            {
                error_return.ErrorType = "No internet Connection!";
                return error_return;
            }
            
        }
    }
}
