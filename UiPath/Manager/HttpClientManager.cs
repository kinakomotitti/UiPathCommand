using KUiPath.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Manager
{
    public static class HttpClientManager
    {
        private static HttpClient Client = new HttpClient();

        /// <summary>
        /// 認証ありのWeb APIを利用する時に利用するパラメータです。
        /// </summary>
        public static string BearerValue { get; set; } = string.Empty;

        public static async Task<T> ExecutePostAsync<T>(string url, T contents)
        {
            //各種設定を行います。
            HttpClientManager.InitializeClient();

            //指定されたContentsを指定されたURLにPOSTします。
            var response =  await HttpClientManager.Client.PostAsJsonAsync<T>(url, contents);

            //レスポンスのContentsをJson形式から指定されたT型のObjectのインスタンスに変換します。
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<T> ExecuteGetAsync<T>(string url)
        {
            //各種設定を行います。
            HttpClientManager.InitializeClient();

            //指定されたContentsを指定されたURLにPOSTします。
            var response = await HttpClientManager.Client.GetStringAsync(url);

            //レスポンスのContentsをJson形式から指定されたT型のObjectのインスタンスに変換します。
            return JsonConvert.DeserializeObject<T>(response);
        }

        private static void InitializeClient()
        {
            HttpClientManager.Client.DefaultRequestHeaders.Accept.Clear();
            HttpClientManager.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClientManager.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpClientManager.BearerValue);
        }
    }
}
