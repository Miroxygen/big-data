using System;

namespace assignment_wt2_oauth
{
    public interface ITweetScraper
    {
        public Task<IEnumerable<object>> GetData();
    }
}
