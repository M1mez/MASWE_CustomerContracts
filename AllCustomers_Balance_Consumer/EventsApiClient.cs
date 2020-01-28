using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AllCustomers_Balance_Consumer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AllCustomers_Balance_Consumer
{
    public class EventsApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public EventsApiClient(string baseUri = null)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://my.api/v2/capture") };
        }

        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public List<Customer> AllCustomersBalance()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "allCustomersBalance");
            request.Headers.Add("Accept", "application/json");

            var response = _httpClient.SendAsync(request);

            try
            {
                var result = response.Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = JsonConvert.DeserializeObject<List<Customer>>(result.Content.ReadAsStringAsync().Result, _jsonSettings);
                    return responseContent;
                }

                RaiseResponseError(request, result);
            }
            finally
            {
                Dispose(request, response);
            }

            return null;
        }

        private static void RaiseResponseError(HttpRequestMessage failedRequest, HttpResponseMessage failedResponse)
        {
            throw new HttpRequestException(
                string.Format("The Events API request for {0} {1} failed. Response status: {2}, Response Body: {3}",
                    failedRequest.Method.ToString().ToUpperInvariant(),
                    failedRequest.RequestUri,
                    (int)failedResponse.StatusCode,
                    failedResponse.Content.ReadAsStringAsync().Result));
        }

        public void Dispose()
        {
            Dispose(_httpClient);
        }

        public void Dispose(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables.Where(d => d != null))
            {
                disposable.Dispose();
            }
        }
    }
}
