namespace FluxToken.Data.DTO.Request
{
    public class CreateTransferFromRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
    }
}