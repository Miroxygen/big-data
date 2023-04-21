using assignment_wt2_oauth;
using Microsoft.Extensions.DependencyInjection;
using dotenv.net;
using Nest;
using Elasticsearch.Net;

DotEnv.Load();

var pool = new CloudConnectionPool(Environment.GetEnvironmentVariable("ELASTIC_CLOUD_ID"), new BasicAuthenticationCredentials("elastic", Environment.GetEnvironmentVariable("ELASTIC_PASSWORD")));
var settings = new ConnectionSettings(pool);
var elasticClient = new ElasticClient(settings);

var serviceProvider = new ServiceCollection()
      .AddSingleton<TweetScraper>()
      .AddSingleton<AddToElastic>()
      .AddSingleton<IElasticClient>(elasticClient)
      .AddSingleton<ZipFileDownloader>()
      .AddSingleton<CsvConverter>()
      .BuildServiceProvider();

//var TweetScraper = serviceProvider.GetService<TweetScraper>();
var addToElastic = serviceProvider.GetService<AddToElastic>();
var zipFileDownloader = serviceProvider.GetService<ZipFileDownloader>();
var csvConverter = serviceProvider.GetService<CsvConverter>();

var downloader = new ZipFileDownloader();
//downloader.DownLoadZipFile();

List<Data> data = csvConverter.convertCsvToObjects();

await addToElastic.AddData(data);





//zipFileDownloader.DownLoadZipFile();

/*var datasetName = "chatgpt-1000-daily-tweets";
var downloadPath = @"C:\path\to\download\directory";
var fetcher = new TweetScraper(datasetName, downloadPath, Environment.GetEnvironmentVariable("KAGGLE_USERNAME"), Environment.GetEnvironmentVariable("KAGGLE_PASSWORD"));
await fetcher.GetData();*/

/*namespace assignment_wt2_oauth

    
{
    class Program
    {
        static async Task Main(string[] args)
        {
            

        }
    }
}*/




