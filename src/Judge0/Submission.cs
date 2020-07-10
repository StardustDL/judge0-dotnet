using System;
using System.Collections;

namespace Judge0
{
    public class Submission
    {
        public string stdout { get; set; }

        public string stderr { get; set; }
        
        public TimeSpan time { get; set; }

        public long memory { get; set; }

        public string token { get; set; }

        public string compile_output { get; set; }

        public string message { get; set; }

        public JudgeStatus status { get; set; }
    }
}
