using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msa_p1_data.Data;
using msa_p1_data.Model;

namespace msa_p1_data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentContext _context;

        public AddressesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.AddressID)
            {
                return BadRequest();
            }

            var updateAddress = await _context.Address.FirstOrDefaultAsync(s => s.AddressID == address.AddressID);
            _context.Entry(updateAddress).State = EntityState.Modified;

            updateAddress.streetNumber = address.streetNumber;
            updateAddress.street = address.street;
            updateAddress.suburb = address.suburb;
            updateAddress.city = address.city;
            updateAddress.postcode = address.postcode;
            updateAddress.country = address.country;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("ChangeByStudentId/{studentId}/{addressId}")]
        public async Task<IActionResult> PutChangeByStudentId(int studentId, int addressId,Address address)
        {
            var studentExist = new StudentsController(_context).StudentExists(studentId);
            if (!studentExist)
            {
                return NotFound();
            }
            if (studentId!=addressId)
            {
                return BadRequest(); 
            }
            return await PutAddress(addressId, address);
        }

        // POST: api/Addresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            var studentExist = new StudentsController(_context).StudentExists(address.StudentId);
            if (!studentExist)
            {
                return NotFound();
            }
            address.timeCreated = DateTime.Now;
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.AddressID }, address);
        }

        // POST: api/Addresses/AddByStudentId
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddByStudentId/{id}")]
        public async Task<ActionResult<Address>> PostAddByStudentId(int id, Address address)
        {

            if(id!=address.StudentId)
            {
                return BadRequest();
            }

            return await PostAddress(address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.AddressID == id);
        }

    }
}
