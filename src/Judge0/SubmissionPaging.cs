﻿using System;
using System.Collections.Generic;

namespace Judge0
{
    public class SubmissionPaging
    {
        public IList<Submission> submissions { get; set; } = Array.Empty<Submission>();

        public PagingMetadata meta { get; set; } = new PagingMetadata();
    }
}
