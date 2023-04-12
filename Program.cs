using assignment_wt2_oauth;
using Microsoft.Extensions.DependencyInjection;
using dotenv.net;

DotEnv.Load();

var serviceProvider = new ServiceCollection();
serviceProvider.AddSingleton<TweetScraper>();
serviceProvider.AddSingleton<AddToElastic>();

namespace assignment_wt2_oauth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            /*var datasetName = "chatgpt-1000-daily-tweets";
            var downloadPath = @"C:\path\to\download\directory";
            var fetcher = new TweetScraper(datasetName, downloadPath, Environment.GetEnvironmentVariable("KAGGLE_USERNAME"), Environment.GetEnvironmentVariable("KAGGLE_PASSWORD"));
            await fetcher.GetData();*/

        }
    }
}




