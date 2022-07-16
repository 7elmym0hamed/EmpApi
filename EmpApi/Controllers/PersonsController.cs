
namespace EmpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region CTOR
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        #endregion

        #region Actions

        #region Get
        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {

            return await _unitOfWork.Persons.GetAllPersons();
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult> Post(PersonDto dto)
        {
            /** Check Name Dublicate*/
            if ( _unitOfWork.Persons.Find(c => c.PersonName.ToLower() == dto.PersonName.ToLower()).Result.Count() >0)
                return Ok(new { Save = false, NameDublicate = true });

            /** Add New person*/
            var person = _mapper.Map<PersonModel>(dto);
            _unitOfWork.Persons.Add(person);
            _unitOfWork.Complete();
            dto.Id = person.Id;
            dto.AddressName = _unitOfWork.Address.Get(dto.AddressId).Result.AddressName;
            return Ok(new { Save = true, Data = dto });
        }
        #endregion

        #region Edit
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, PersonDto dto)
        {
            /** Check Name Dublicate*/
            if (_unitOfWork.Persons.Find(c => c.Id != Id && c.PersonName.ToLower() == dto.PersonName.ToLower()).Result.Count() > 0)
                return Ok(new { Update = false, NameDublicate = true, NotFound = false });

            /** Check Found Persons*/
            var person =await _unitOfWork.Persons.Get(Id);
            if (person == null)
                return Ok(new { Update = false, NameDublicate = false, NotFound = true });

            /** Update Persons*/
            person.PersonName = dto.PersonName;
            person.Age = dto.Age;
            person.AddressId = dto.AddressId;
            _unitOfWork.Complete();
            dto.AddressName = _unitOfWork.Address.Get(dto.AddressId).Result.AddressName;

            return Ok(new { Update = true, Data = dto });
        }
        #endregion

        #region Delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var person =await _unitOfWork.Persons.Get(Id);
            if (person == null)
                return Ok(new { delete = false, CheckPersons = false, NotFound = true });

            _unitOfWork.Persons.Remove(person);
            _unitOfWork.Complete();
            return Ok(new { delete = true });
        }
        #endregion


        #endregion

    }
}
