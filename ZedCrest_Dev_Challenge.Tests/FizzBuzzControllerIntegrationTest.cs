using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;
using ZedCrest_Dev_Challenge.Models;

namespace ZedCrest_Dev_Challenge.Tests
{
    public class FizzBuzzControllerIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public FizzBuzzControllerIntegrationTest()
        {
            var host = new WebHostBuilder()
               .UseStartup<Startup>();

            _server = new TestServer(host);
            _client = _server.CreateClient();
        }

        /// <summary>
        /// This test checks for all odd numbers between 1 and 100
        /// </summary>
        [Fact]
        public void CheckOddNumbers()
        {
            List<int> GenerateOddNumbers = new List<int>();
            for (int i=3; i<=100; i+=3)
            {
                GenerateOddNumbers.Add(i); // Add OddNumbers
            }

           
            foreach(var oddNumber in GenerateOddNumbers)
            {
                Request req = new Request
                {
                    Number = oddNumber
                };

                var content = JsonConvert.SerializeObject(req);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response =  _client.PostAsync("/api/FizzBuzz", stringContent).Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                var registered = JsonConvert.DeserializeObject<Response<string>>(responseString);

                Assert.Equal("Fizz", registered.Data);
            }
        }

    }
}
