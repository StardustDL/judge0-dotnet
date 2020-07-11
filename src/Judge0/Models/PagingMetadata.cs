namespace Judge0.Models
{
    public class PagingMetadata
    {
        public int? current_page { get; set; }

        public int? next_page { get; set; }

        public int? prev_page { get; set; }

        public int? total_pages { get; set; }

        public int? total_count { get; set; }
    }
}
