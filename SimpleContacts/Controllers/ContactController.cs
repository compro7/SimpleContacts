using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleContacts.Models;

namespace SimpleContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDBContext _context;
        public ContactController(ContactDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return _context.Contacts.ToList();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            return contact == null  ? NotFound() : Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = contact.Id}, contact);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (id != contact.Id) return BadRequest();
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            
            var contacttoDelete = await _context.Contacts.FindAsync(id);
            if (contacttoDelete == null) return NotFound();

            _context.Contacts.Remove(contacttoDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
