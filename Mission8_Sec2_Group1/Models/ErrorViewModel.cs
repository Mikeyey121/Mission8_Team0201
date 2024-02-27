namespace Mission8_Sec2_Group1.Models
{
    public class ErrorViewModel
    {
        
        // This is Davis' section
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Name { get; set; }
    }
}
