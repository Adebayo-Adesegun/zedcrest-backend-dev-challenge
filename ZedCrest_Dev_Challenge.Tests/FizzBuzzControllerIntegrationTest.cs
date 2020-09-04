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
        /// This test checks for numbers that are multiple of 3
        /// </summary>
        [Fact]
        public void AreMultiplesofThree()
        {
            List<int> multiplesOfThree = new List<int>();
            for (int i=3; i<=100; i+=3)
            {
                multiplesOfThree.Add(i); // Add OddNumbers
            }

           
            foreach(var multiple in multiplesOfThree)
            {
                Request req = new Request
                {
                    Number = multiple
                };

                var content = JsonConvert.SerializeObject(req);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response =  _client.PostAsync("/api/FizzBuzz", stringContent).Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                var buzzy = JsonConvert.DeserializeObject<Response<string>>(responseString);

                Assert.True(buzzy.Data == "Fizz" || buzzy.Data == "FizzBuzz", "Failed");
            }
        }


        [Fact]
        public void AreMultiplesOfFive()
        {
            List<int> multiplesOfFive = new List<int>();
            for (int i = 5; i <= 100; i += 5)
            {
                multiplesOfFive.Add(i); // Add OddNumbers
            }


            foreach (var multiple in multiplesOfFive)
            {
                Request req = new Request
                {
                    Number = multiple
                };

                var content = JsonConvert.SerializeObject(req);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = _client.PostAsync("/api/FizzBuzz", stringContent).Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                var buzzy = JsonConvert.DeserializeObject<Response<string>>(responseString);

                Assert.True(buzzy.Data == "Buzz" || buzzy.Data == "FizzBuzz", "Failed");
            }
        }

    }
}
