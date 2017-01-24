using Microsoft.AspNetCore.Mvc;
using Sync1.Model;
using Sync1.WebAPI.Repository;
using System.Collections.Generic;

namespace Sync1.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {

        ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get() => _companyRepository.GetAllEmployee();

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id) => _companyRepository.Get(id);

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Employee value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            return Ok(_companyRepository.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee value)
        {
            var actual = _companyRepository.Get(id);

            if (actual == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _companyRepository.Update(id, value);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var actual = _companyRepository.Get(id);

            if (actual == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_companyRepository.Delete(id));
        }
    }
}
