using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ServicesDemo.Common
{
    public static class WebServiceManager<T>
    {

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<T> GetData(string latitute, string longitude)
        {
            try
            {
                var address1 = string.Format("https://samples.openweathermap.org/data/2.5/find?lat={0}&lon={1}&cnt=10&appid=b6907d289e10d714a6e88b30761fae22", latitute, longitude);
                                   var address = Uri.EscapeUriString(address1);
                using (var client = GetClient())
                {
                    var response = await client.GetAsync(address);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(data);
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);

                return default(T);

            }
        }

        //public static async Task<T> PostData(object obj)
        //{
        //    try
        //    {
        //        var address = Uri.EscapeUriString("https://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b6907d289e10d714a6e88b30761fae22");
        //        .
        //        using (var client = GetClient())
        //        {
        //            var response = await client.PostAsync(address, JsonContentFactory.CreateJsonContent(postObject));
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var data = await response.Content.ReadAsStringAsync();
        //                return JsonConvert.DeserializeObject<T>(data);
        //            }
        //            else
        //            {
        //                return default(T);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.Write(ex.Message);

        //        return default(T);

        //    }
        //}


        //public static class JsonContentFactory
        //{
        //    public static StringContent CreateJsonContent(object obj)
        //    {
        //        var json = JsonConvert.SerializeObject(obj);
        //        var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        //        return content;
        //    }
        //}


    }
}
