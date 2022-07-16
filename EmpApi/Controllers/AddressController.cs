

namespace EmpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        #region CTOR
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        #endregion

        #region Actions

        #region Get
        [HttpGet]
        public async Task<ActionResult<List<AddessDto>>> Get()
        {

            return await _unitOfWork.Address.GetAllAddress();
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult> Post(AddessDto dto)
        {
            /** Check Name Dublicate*/
            if (_unitOfWork.Address.Find(c => c.AddressName.ToLower() == dto.AddressName.ToLower()).Result.Count() > 0)
                return Ok(new { Save = false, NameDublicate = true });

            /** Add New Address*/
            var address = _mapper.Map<AddressModel>(dto);
            _unitOfWork.Address.Add(address);
            _unitOfWork.Complete();
            dto.Id = address.Id;
            return Ok(new { Save = true, Data = dto });
        }
        #endregion

        #region Edit
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, AddessDto dto)
        {
            /** Check Name Dublicate*/
            if (_unitOfWork.Address.Find(c => c.Id != Id && c.AddressName.ToLower() == dto.AddressName.ToLower()).Result.Count() > 0)
                return Ok(new { Update = false, NameDublicate = true, NotFound = false });

            /** Check Found Address*/
            var address =await _unitOfWork.Address.Get(Id);
            if (address == null)
                return Ok(new { Update = false, NameDublicate = false, NotFound = true });

            /** Update Address*/
            address.AddressName = dto.AddressName;
            _unitOfWork.Complete();

            return Ok(new { Update = true });
        }
        #endregion

        #region Delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var address =await _unitOfWork.Address.Get(Id);
            if (address == null)
                return Ok(new { delete = false, CheckPersons = false, NotFound = true });


            if (address.Persons.Count() > 0)
                return Ok(new { delete = false, CheckPersons = true, NotFound = false });

            _unitOfWork.Address.Remove(address);
            _unitOfWork.Complete();
            return Ok(new { delete = true });
        }
        #endregion


        #endregion

    }
}
