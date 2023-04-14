using System;
using System.IO.Compression;

namespace assignment_wt2_oauth
{
    public class ZipFileDownloader
    {

      public void DownLoadZipFile()
      {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string zipFileName = "chatgpt-1000-daily-tweets.zip";
        string zipPath = Path.Combine(desktopPath, zipFileName);
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../");
        ZipFile.ExtractToDirectory(zipPath, rootPath);
        
      }
        
    }
}
