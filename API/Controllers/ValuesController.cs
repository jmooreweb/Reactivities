﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly DataContext _context;

		public ValuesController(DataContext context)
		{
			_context = context;
		}

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
			var values = await _context.Values.ToListAsync();
			return Ok(values);
        }

        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Value>> Get(int id)
        {
			var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
