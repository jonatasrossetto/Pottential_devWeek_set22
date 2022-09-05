// usar o dotnet watch run para hotreload do projeto

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using src.Models;
using src.Persistence;


namespace src.Controllers;

[ApiController] // anotação
[Route("[controller]")]  // a rota será Person
public class PersonController : ControllerBase
{
    private DatabaseContext _context { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }



    [HttpGet]
    public ActionResult<List<Person>> Get()
    {
        // Person pessoa = new Person("Jônatas", 48);
        // Contrato contrato = new Contrato(13, "12345");
        // pessoa.Contratos.Add(contrato);
        var result = _context.Pessoas.Include(p => p.Contratos).ToList();
        if (!result.Any())
        {
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Post(Person pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return Created("registro criado com sucesso", pessoa);
    }
    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person pessoa)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        if (result is null)
        {
            return NotFound(new
            {
                msg = "id: " + id + " não encontrado",
                status = HttpStatusCode.NotFound
            });
        }
        try
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }
        catch
        {
            return BadRequest(new
            {
                msg = "Erro ao tentar atualizar os dados do id: " + id,
                status = HttpStatusCode.BadRequest
            });
        }


        return Ok(new
        {
            msg = "Dados do id: " + id + " atualizados.",
            status = HttpStatusCode.OK
        });
    }
    // [HttpDelete("{id}")]
    // public string Delete([FromRoute] int id)
    // {
    //     var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
    //     _context.Pessoas.Remove(result);
    //     _context.SaveChanges();
    //     Console.WriteLine(result.Nome);
    //     return "O id " + id + " foi apagado com sucesso.";
    // }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        if (result is null) return BadRequest(new
        {
            msg = "O Id solicitado não existe na base de dados",
            status = HttpStatusCode.BadRequest
        });
        return Ok(new
        {
            msg = "O id " + id + " foi apagado com sucesso.",
            status = HttpStatusCode.OK
        });
    }

}