using System;
using CsvHelper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace assignment_wt2_oauth
{
    public class CsvConverter
    {
        public List<Data> convertCsvToObjects()
        {
          var reader = new StreamReader("chatgpt_daily_tweets.csv");
          var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
          {
            var records = csvReader.GetRecords<Data>();
            var data = new List<Data>();
            data.AddRange(records);
            //var newData = JsonConvert.SerializeObject(records);
            return data;
          }
        }
    }
        public class Data
  {
      [Name("tweet_id")]
      public string? TweetId { get; set; }

      [Name("tweet_created")]
      public DateTime? TweetCreated { get; set; }

      [Name("text")]
      public string? Text { get; set; }

      [Name("lang")]
      public string? Lang { get; set; }

      [Name("user_id")]
      public string? UserId { get; set; }

      [Name("user_name")]
      public string? UserName { get; set; }

      [Name("user_username")]
      public string? UserUsername { get; set; }

      [Name("user_location")]
      public string? UserLocation { get; set; }

      [Name("user_description")]
      public string? UserDescription { get; set; }

      [Name("user_created")]
      public DateTime? UserCreated { get; set; }

      [Name("user_followers_count")]
      public double? UserFollowersCount { get; set; }

      [Name("user_following_count")]
      public double? UserFollowingCount { get; set; }

      [Name("user_tweet_count")]
      public double? UserTweetCount { get; set; }

      [Name("user_verified")]
      public bool? UserVerified { get; set; }

      [Name("source")]
      public string? Source { get; set; }

      [Name("retweet_count")]
      public double? RetweetCount { get; set; }

      [Name("like_count")]
      public double? LikeCount { get; set; }

      [Name("reply_count")]
      public double? ReplyCount { get; set; }

      [Name("impression_count")]
      public double? ImpressionCount { get; set; }
  }


}
