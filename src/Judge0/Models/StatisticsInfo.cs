using System;
using System.Collections.Generic;

namespace Judge0.Models
{
    public class StatisticsInfo
    {
        public class DataBaseInfo
        {
            public string size_pretty { get; set; } = string.Empty;

            public long size_in_bytes { get; set; }
        }

        public class SubmissionsInfo
        {
            public int total { get; set; }

            public int today { get; set; }

            public IDictionary<string, int> last_30_days { get; set; } = new Dictionary<string, int>();
        }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset cached_until { get; set; }

        public IList<Language> languages { get; set; } = Array.Empty<Language>();

        public IList<JudgeStatus> status { get; set; } = Array.Empty<JudgeStatus>();

        public SubmissionsInfo submissions { get; set; } = new SubmissionsInfo();

        public DataBaseInfo database { get; set; } = new DataBaseInfo();
    }
}
