using System;
using System.Collections;

namespace Judge0
{
    public class Submission
    {
        public string stdout { get; set; } = string.Empty;

        public string stderr { get; set; } = string.Empty;

        public TimeSpan time { get; set; }

        public long memory { get; set; }

        public string token { get; set; } = string.Empty;

        public string compile_output { get; set; } = string.Empty;

        public string message { get; set; } = string.Empty;

        public JudgeStatus status { get; set; } = new JudgeStatus();
    }
}
