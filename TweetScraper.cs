using System.Text;
using RestSharp;

namespace assignment_wt2_oauth
{
  public class TweetScraper
  {
    private readonly string _datasetName;
    private readonly string _downloadPath;
    private readonly string _kaggleUsername;
    private readonly string _kaggleApiKey;

    public TweetScraper(string datasetName, string downloadPath, string kaggleUsername, string kaggleApiKey)
        {
            _datasetName = datasetName;
            _downloadPath = downloadPath;
            _kaggleUsername = kaggleUsername;
            _kaggleApiKey = kaggleApiKey;
        }
    public async Task GetData()
    {
      var restClient = new RestClient("https://www.kaggle.com/api/v1");

      //var restClient = new RestClient("https://www.kaggle.com/api/v1/datasets/download/edomingo/chatgpt-1000-daily-tweets?username=" + _kaggleUsername  + "&key=" + _kaggleApiKey);

      var data = new List<object>();

      var request = new RestRequest("/datasets/download/edomingo/chatgpt-1000-daily-tweets", Method.Get);
      var authString = $"{_kaggleUsername}:{_kaggleApiKey}";
      var encodedAuthString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authString));
      request.AddHeader("Authorization", $"Basic {encodedAuthString}");

      var response = await restClient.ExecuteGetAsync(request);

      if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to download dataset: {response.StatusCode} - {response.ErrorMessage}");
            }
      var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      
      var filePath = Path.Combine(desktopPath, _datasetName + ".zip");

      Console.WriteLine(response);

      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        await fileStream.WriteAsync(response.RawBytes, 0, response.RawBytes.Length);
      }
    }
  }
}
