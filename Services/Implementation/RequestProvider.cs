using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using MauiTestApp.Models;
using MauiTestApp.Services.Interface;

namespace MauiTestApp.Services.Implementation
{
    public class RequestProvider:IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;
        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        //public async Task<TResult> PostAsync<TResult>(string url, StringContent stringContent, string token = "", string header = "")
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        }

        //        if (!string.IsNullOrEmpty(header))
        //        {
        //            httpClient.DefaultRequestHeaders.Add(header, "");
        //        }

        //        try
        //        {
        //            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);
        //            response.EnsureSuccessStatusCode(); 

        //            string responseContent = await response.Content.ReadAsStringAsync();
        //            TResult result = JsonConvert.DeserializeObject<TResult>(responseContent);

        //            return result;
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("An error occurred during the login request: " + ex.Message);
        //            return default(TResult);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("An unexpected error occurred during login: " + ex.Message);
        //            throw;
        //        }
        //    }
        //}

        public async Task<TResult> PostAsync<TResult>(string uri, StringContent stringContent, string token = "", string header = "")
        {

            HttpClient httpClient = CreateHttpClient(token);
            httpClient = new HttpClient();
            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, stringContent);

            await HandleResponse(response);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                //Device.InvokeOnMainThreadAsync(async () =>
                //{
                //    await Toast.Make("Response Okay!", ToastDuration.Long, 16).Show(cancellationTokenSource.Token);
                //});
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                
            }
            string serialized = await response.Content.ReadAsStringAsync(); //

            TResult result = await Task.Run(() =>
         JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings)); //
            return result;
        }
        private HttpClient CreateHttpClient(string token = "")
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }

        private void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrEmpty(parameter))
                return;

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            string content;
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            else if (!response.IsSuccessStatusCode)
            {
                try
                {
                    content = await response.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        var data = JsonConvert.DeserializeObject<ErrorModel>(content);
                        if (data != null)
                        {
                            if (!string.IsNullOrEmpty(data.error.message))
                            {
                                content = data.error.message;
                            }
                            else
                            {
                                content = "something went wrong!";
                            }
                        }
                    }
                    else
                    {
                        content = "something went wrong!";
                    }

                }
                catch (Exception ex)
                {
                    content = "something went wrong!";
                }
            }



        }


    }
}
