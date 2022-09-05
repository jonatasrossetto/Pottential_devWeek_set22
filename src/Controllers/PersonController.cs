// usar o dotnet watch run para hotreload do projeto

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
    public List<Person> Get()
    {
        // Person pessoa = new Person("Jônatas", 48);
        // Contrato contrato = new Contrato(13, "12345");
        // pessoa.Contratos.Add(contrato);

        return _context.Pessoas.Include(p => p.Contratos).ToList();
    }
    [HttpPost]
    public Person Post(Person pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return pessoa;
    }
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person pessoa)
    {
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
        Console.WriteLine("id: " + id);
        Console.WriteLine(pessoa);
        return "Dados do id: " + id + " atualizados.";
    }
    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        _context.Pessoas.Remove(result);
        _context.SaveChanges();
        Console.WriteLine(result.Nome);
        return "O id " + id + " foi apagado com sucesso.";
    }
}