using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore_3_0.Context;
using WebApiCore_3_0.Entities;
using WebApiCore_3_0.Services;

namespace WebApiCore_3_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IClassB classB;
        public CreatorsController(ApplicationDBContext context, IClassB classB)
        {
            this.context = context;
            this.classB = classB;
        }

        [HttpGet("{id}", Name = "GetCreator")]
        public async Task<ActionResult<Creator>> Get(int id)
        {
            var creator = await context.Creators.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);

            if (creator == null)
            {
                return NotFound();
            }

            return creator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creator>>> Get()
        {
            classB.DoSomething();
            return await context.Creators.Include(x => x.Books).ToListAsync();
        }

        [HttpGet("first")]
        public ActionResult<Creator> GetFirst()
        {
            return context.Creators.Include(x => x.Books).FirstOrDefault();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Creator creator)
        {
            context.Creators.Add(creator);
            context.SaveChanges();

            return new CreatedAtRouteResult("GetCreator", new { id = creator.Id }, creator);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Creator creator)
        {

            if (id != creator.Id)
            {
                return BadRequest();
            }

            context.Entry(creator).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Creator> Delete(int id)
        {
            var creator = context.Creators.FirstOrDefault(x => x.Id == id);

            if (creator == null)
            {
                return NotFound();
            }

            context.Creators.Remove(creator);
            context.SaveChanges();

            return creator;
        }
    }
}