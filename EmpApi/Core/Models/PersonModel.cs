

namespace EmpApi.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string PersonName { get; set; }
        public short Age { get; set; }
        [ForeignKey("AddressModel")]
        public int AddressId { get; set; }
        public virtual AddressModel Address { get; set; }
    }
}
