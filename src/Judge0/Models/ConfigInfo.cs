using System;
using System.Collections.Generic;

namespace Judge0.Models
{

    public class ConfigInfo
    {
        public bool enable_wait_result { get; set; } = true;

        public bool enable_compiler_options { get; set; } = true;

        public IList<string> allowed_languages_for_compile_options { get; set; } = Array.Empty<string>();

        public bool enable_command_line_arguments { get; set; } = true;

        public bool enable_submission_delete { get; set; } = false;

        public int max_queue_size { get; set; } = 100;

        public double cpu_time_limit { get; set; } = 2;

        public double cpu_extra_time { get; set; } = 0.5;

        public double wall_time_limit { get; set; } = 5;

        public int memory_limit { get; set; } = 128000;

        public int stack_limit { get; set; } = 64000;

        public int max_processes_and_or_threads { get; set; } = 60;

        public bool enable_per_process_and_thread_time_limit { get; set; } = false;

        public bool enable_per_process_and_thread_memory_limit { get; set; } = true;

        public int max_file_size { get; set; } = 1024;

        public int number_of_runs { get; set; } = 1;

        public double max_cpu_time_limit { get; set; } = 15;

        public double max_cpu_extra_time { get; set; } = 2;

        public double max_wall_time_limit { get; set; } = 20;

        public int max_memory_limit { get; set; } = 256000;

        public int max_stack_limit { get; set; } = 128000;

        public int max_max_processes_and_or_threads { get; set; } = 120;

        public bool allow_enable_per_process_and_thread_time_limit { get; set; } = true;

        public bool allow_enable_per_process_and_thread_memory_limit { get; set; } = true;

        public int max_max_file_size { get; set; } = 4096;

        public int max_number_of_runs { get; set; } = 20;
    }
}
