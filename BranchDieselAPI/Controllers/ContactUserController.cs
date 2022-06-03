using BranchDieselAPI.Data;
using BranchDieselAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BranchDieselAPI.Controllers
{
    //data anotation
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUserController : Controller
    {
        private readonly BranchDieselAPIDbContext dbContext;
        public ContactUserController(BranchDieselAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //make all methos asynchronous
        [HttpGet]
        public async Task<IActionResult> GetContactUsers()
        {
            return Ok(await dbContext.ContactUsers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContactUser([FromRoute] Guid id)
        {
            var contactuser = await dbContext.ContactUsers.FindAsync(id);
            if (contactuser == null)
            {
                return NotFound();
            }
            return Ok(contactuser);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(AddDieselRequest addDieselRequest) 
        {
            var contactuser = new ContactUser()
            {
                Id = Guid.NewGuid(),
                FullName = addDieselRequest.FullName,
                Email = addDieselRequest.Email,
                Phone = addDieselRequest.Phone,
                Branch = addDieselRequest.Branch,
                RequestQty = addDieselRequest.RequestQty,
                ActualQty = addDieselRequest.ActualQty
            };

            //point the object to the Db via DbC
            await dbContext.ContactUsers.AddAsync(contactuser);
            await dbContext.SaveChangesAsync();

            return Ok(contactuser); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDiesel([FromRoute] Guid id, UpdateDieselRequest updateDieselRequest) 
        {
            var contactuser = await dbContext.ContactUsers.FindAsync(id);

            if (contactuser != null)
            {
                contactuser.Branch = updateDieselRequest.Branch;
                contactuser.FullName = updateDieselRequest.FullName;
                contactuser.Email = updateDieselRequest.Email;
                contactuser.Phone = updateDieselRequest.Phone;
                contactuser.RequestQty = updateDieselRequest.RequestQty;
                contactuser.ActualQty = updateDieselRequest.ActualQty;

                await dbContext.SaveChangesAsync();

                return Ok(contactuser);
            }
            return NotFound();
        }

    }
}
