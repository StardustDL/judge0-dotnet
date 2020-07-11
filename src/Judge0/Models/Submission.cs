using System;
using System.Collections;
using System.Text;
using System.Text.Json;

namespace Judge0.Models
{

    public class Submission
    {
        public string? source_code { get; set; }

        public int? language_id { get; set; }

        public string? compiler_options { get; set; }

        public string? command_line_arguments { get; set; }

        public string? stdin { get; set; }

        public string? expected_output { get; set; }

        public string? cpu_time_limit { get; set; }

        public string? cpu_extra_time { get; set; }

        public string? wall_time_limit { get; set; }

        public string? memory_limit { get; set; }

        public int? stack_limit { get; set; }

        public int? max_processes_and_or_threads { get; set; }

        public bool? enable_per_process_and_thread_time_limit { get; set; }

        public bool? enable_per_process_and_thread_memory_limit { get; set; }

        public int? max_file_size { get; set; }

        public bool? redirect_stderr_to_stdout { get; set; }

        public int? number_of_runs { get; set; }

        public string? additional_files { get; set; }

        public string? callback_url { get; set; }

        public string? stdout { get; set; }

        public string? stderr { get; set; }

        public string? compile_output { get; set; }

        public string? message { get; set; }

        public int? exit_code { get; set; }

        public int? exit_signal { get; set; }

        public string? created_at { get; set; }

        public string? finished_at { get; set; }

        public string? token { get; set; }

        public string? time { get; set; }

        public string? wall_time { get; set; }

        public double? memory { get; set; }

        public JudgeStatus? status { get; set; }

        public Submission Base64Encode()
        {
            static string? ToBase64(string? value)
            {
                if (value is null)
                    return null;
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }

            Submission result = JsonSerializer.Deserialize<Submission>(JsonSerializer.Serialize(this));
            result.stdin = ToBase64(result.stdin);
            result.source_code = ToBase64(result.source_code);
            result.expected_output = ToBase64(result.expected_output);
            result.stdout = ToBase64(result.stdout);
            result.stderr = ToBase64(result.stderr);
            result.compile_output = ToBase64(result.compile_output);
            result.message = ToBase64(result.message);
            return result;
        }

        public Submission Base64Decode()
        {
            static string? FromBase64(string? value)
            {
                if (value is null)
                    return null;
                return Encoding.UTF8.GetString(Convert.FromBase64String(value));
            }

            Submission result = JsonSerializer.Deserialize<Submission>(JsonSerializer.Serialize(this));
            result.stdin = FromBase64(result.stdin);
            result.source_code = FromBase64(result.source_code);
            result.expected_output = FromBase64(result.expected_output);
            result.stdout = FromBase64(result.stdout);
            result.stderr = FromBase64(result.stderr);
            result.compile_output = FromBase64(result.compile_output);
            result.message = FromBase64(result.message);
            return result;
        }
    }
}
