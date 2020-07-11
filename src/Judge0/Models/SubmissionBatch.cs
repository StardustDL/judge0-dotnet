using System;
using System.Collections.Generic;

namespace Judge0.Models
{
    public class SubmissionBatch
    {
        public IList<Submission> submissions { get; set; } = Array.Empty<Submission>();
    }
}
