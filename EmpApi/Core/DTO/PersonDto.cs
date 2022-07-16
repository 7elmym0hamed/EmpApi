namespace EmpApi.Core.DTO
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string PersonName { get; set; }
        public short Age { get; set; }
        public int AddressId { get; set; }
        public string? AddressName { get; set; }
    }
}
