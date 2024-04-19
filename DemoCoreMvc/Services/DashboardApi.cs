using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DemoCoreMvc.Models;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Cryptography;


namespace DemoCoreMvc.Services
{
    public class DashboardApi
    {
        public string base_url = "http://127.0.0.1:5001";
                 
        public JArray get_all_years()
        {
            var httpClient = new HttpClient();                      
            string api_url = base_url + "/api/all_years";                
            var result = httpClient.GetAsync(api_url).GetAwaiter().GetResult();                
            string years = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();                                                                 
            JArray list_years = JArray.Parse(years); 
            return list_years;                                       
        }           
        public JObject get_loan_amt(string year)
        {
            var url = base_url + "/api/loan_amt";
            var post_data = new { yyyy= year };
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        } 
        public JObject get_loan_count(string year)
        {
            var url = base_url + "/api/loan_count";
            var post_data = new { yyyy = year };
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        } 

        public JObject get_default_amt(string year)
        {
            var url = base_url + "/api/default_amt";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        } 

        public JObject get_default_count(string year)
        {
            var url = base_url + "/api/default_count";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        } 

        public JObject get_month_loan(string year)
        {
            var url = base_url + "/api/month_loan";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        } 

          public JObject get_month_count(string year)
        {
            var url = base_url + "/api/month_count";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        }   

        public JObject get_purpose(string year)
        {
            var url = base_url + "/api/purpose";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        }   

        public JObject get_occupation(string year)
        {
            var url = base_url + "/api/occupation";
            var post_data = new { yyyy = year};
            string post_content = JsonConvert.SerializeObject(post_data);                       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;            
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();            
            return JObject.Parse(strResponse);
        }                  

    }
}
