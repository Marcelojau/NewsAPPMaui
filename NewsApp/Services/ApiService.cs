using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Services
{
    public class ApiService
    {
        public async Task<Root> GetNews(string categoryName = null)
        {
            var httpClient = new HttpClient();

            categoryName = categoryName == null ? "Sports" : categoryName;

            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?token=your_token&lang=en&topic={categoryName.ToLower()}");

            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
