using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HackerNews.Models
{
    public class StoryRepository
    {
       // static void Main() => RunAsync().Wait();

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("BestStories");
                if (response.IsSuccessStatusCode)
                {
                    Story story = await response.Content.ReadAsAsync<Story>();
                    Console.WriteLine("{0}\t${1}\t{2}", story.Id, story.Title, story.Author);
                }
            }
        }
    }
}

