using System;
using System.Collections;

namespace Judge0.Models
{

    public class Submission
    {
        public string source_code { get; set; } = string.Empty;

        public int language_id { get; set; }

        public string? compiler_options { get; set; }

        public string? command_line_arguments { get; set; }

        public string? stdin { get; set; }

        public string? expected_output { get; set; }

        public double? cpu_time_limit { get; set; }

        public double? cpu_extra_time { get; set; }

        public double? wall_time_limit { get; set; }

        public double? memory_limit { get; set; }

        public int? stack_limit { get; set; }

        public int? max_processes_and_or_threads { get; set; }

        public bool? enable_per_process_and_thread_time_limit { get; set; }

        public bool? enable_per_process_and_thread_memory_limit { get; set; }

        public int? max_file_size { get; set; }

        public bool? redirect_stderr_to_stdout { get; set; }

        public int? number_of_runs { get; set; }

        public string? additional_files { get; set; }

        public string? callback_url { get; set; }

        public string stdout { get; set; } = string.Empty;

        public string stderr { get; set; } = string.Empty;

        public string compile_output { get; set; } = string.Empty;

        public string message { get; set; } = string.Empty;

        public int exit_code { get; set; }

        public int exit_signal { get; set; }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset? finished_at { get; set; }

        public string token { get; set; } = string.Empty;

        public double time { get; set; }

        public double wall_time { get; set; }

        public double memory { get; set; }

        public JudgeStatus status { get; set; } = new JudgeStatus();
    }
}
