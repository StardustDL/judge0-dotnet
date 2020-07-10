using System.Collections.Generic;

namespace Judge0
{
    public class SubmissionPaging
    {
        public IList<Submission> submissions { get; set; }

        public PagingMetadata meta { get; set; }
    }
}
