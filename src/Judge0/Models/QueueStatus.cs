namespace Judge0.Models
{
    public class QueueStatus
    {
        public string queue { get; set; } = string.Empty;
        
        public int available { get; set; }

        public int idle { get; set; }

        public int working { get; set; }

        public int paused { get; set; }

        public int failed { get; set; }
    }
}
