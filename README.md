# Kaggle Twitter Data Scraper and Elasticsearch Integration

This project scrapes Twitter data from Kaggle, processes it, and stores it in an Elasticsearch instance. It provides functionalities to download data from Kaggle, convert CSV data to objects, and index this data into Elasticsearch.

## Core Functionalities

  -  Download Data: Scrape and download a dataset from Kaggle using Kaggle's API.
 -   CSV Conversion: Convert downloaded CSV data into .NET objects.
 -   Data Indexing: Index the processed data into an Elasticsearch instance.
 -   Data Retrieval: Retrieve indexed data from Elasticsearch.

### Technologies Used

 -   .NET 7.0: Main framework for building the application.
 -   Kaggle API: For downloading datasets.
 -   CSVHelper: For converting CSV data into .NET objects.
 -   Elasticsearch: For storing and retrieving data.
 -   Nest: Elasticsearch client for .NET.
 -   RestSharp: For making HTTP requests to Kaggle's API.
  -  dotenv.net: For managing environment variables.

## Project Structure

  -  AddToElastic.cs: Handles the indexing of data into Elasticsearch.
   - CsvConverter.cs: Converts CSV data into .NET objects.
 -   Data.cs: Model class representing the structure of the data.
  -  GetFromElastic.cs: Provides methods to retrieve data from Elasticsearch.
  -  TweetScraper.cs: Downloads data from Kaggle.
  -  ZipFileDownloader.cs: Extracts downloaded ZIP files.
  -  Program.cs: Sets up dependency injection and runs the data processing and indexing workflow.

## Setup

  1. Clone the repository.

2. Install dependencies:

   -   Ensure you have .NET 7.0 SDK installed.

3. Set up environment variables in a .env file.

4. Run the application:

    -  dotnet run

## Environment Variables

-    ELASTIC_CLOUD_ID: The ID of your Elastic Cloud instance.
-    ELASTIC_PASSWORD: The password for your Elastic Cloud instance.
-    KAGGLE_USERNAME: Your Kaggle username.
-    KAGGLE_API_KEY: Your Kaggle API key.

## Dependencies

-    CsvHelper: 30.0.1
-    dotenv.net: 3.1.2
-    Microsoft.Extensions.DependencyInjection: 7.0.0
-    NEST: 7.17.5
-    Newtonsoft.Json: 13.0.3
-    RestSharp: 110.2.0

## License

This project is licensed under the MIT License.
