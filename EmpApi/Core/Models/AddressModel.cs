namespace EmpApi.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            Persons = new HashSet<PersonModel>();

        }
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string AddressName { get; set; }
        public virtual ICollection<PersonModel> Persons { get; set; }
    }
}
