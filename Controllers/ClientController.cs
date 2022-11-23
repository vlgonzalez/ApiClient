using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClient.Context;
using ApiClient.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class ClientController : ControllerBase
   {
     private readonly ClientContext _context;
        
        public ClientController( ClientContext context)
        {
            _context = context;
        }

    [HttpPost("CriarCliente")]    
    public IActionResult Create(Client client)
    {                    
                _context.Clients.Add(client);
                _context.SaveChanges();
                return CreatedAtAction(nameof(ObterPorId), new{id = client.Id}, client);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var client =_context.Clients.Find(id);

        if (client == null)
        return NotFound();

        return Ok(client);
    }

    [HttpPatch("{id}")]
    public IActionResult Atualizar(int id,  string cardName)
    {
        var clientBanco = _context.Clients.Find(id);
        if(clientBanco ==null)
        return NotFound();

        clientBanco.CardName = cardName;

        _context.Clients.Update(clientBanco);
        _context.SaveChanges();

        return Ok(clientBanco.CardName);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
       var clientBanco =_context.Clients.Find(id);

        if (clientBanco == null)
        return NotFound();

        _context.Clients.Remove(clientBanco);
        _context.SaveChanges();

        return NoContent();
   }
}
}