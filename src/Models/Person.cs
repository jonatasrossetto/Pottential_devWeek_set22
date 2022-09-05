using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Nome = "template";
        this.Idade = 0;
    }
    public Person(string Nome, int Idade)
    {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Contratos = new List<Contrato>();
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public bool? Ativo { get; set; }
    public string? Cpf { get; set; }
    public List<Contrato> Contratos { get; set; }


}