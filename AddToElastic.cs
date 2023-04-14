using System;
using System.Text;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json.Linq;

namespace assignment_wt2_oauth
{
    public class AddToElastic
    {
    private readonly IElasticClient elasticClient;

    public AddToElastic(IElasticClient elasticClient)
      {
      this.elasticClient = elasticClient;
    }
        public async Task AddData(IEnumerable<Data> datas)
        {
          try
          {
            var index = "tweeteddata";
          var batchSize = 200;
          var shipped = 0;
          while(datas.Skip(shipped).Take(batchSize).Any()) {
            var batch = datas.Skip(shipped).Take(batchSize);
            var response = await elasticClient.BulkAsync(b => b.CreateMany(batch).Index(index));
            shipped += batchSize;
            if (!response.IsValid)
            {
                Console.WriteLine($"Error occurred while adding data to Elasticsearch: {response.ToString()}");
            }
            shipped += response.Items.Count(i => i.IsValid);
            Console.WriteLine($"{shipped} data items shipped to Elasticsearch");
          }
          }
          catch (ElasticsearchClientException ex)
          {
            Console.WriteLine($"Elasticsearch error: {ex.Message}");
            throw;
          }
          

        }
    }
}
