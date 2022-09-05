using src.Models;

namespace src.Models;

public class Contrato
{
    public Contrato()
    {
        this.DataCriacao = DateTime.Now;
        this.TokenId = "00000";
        this.Valor = 0;
    }
    public Contrato(double valor, string tokenId)
    {
        this.DataCriacao = DateTime.Now;
        this.TokenId = tokenId;
        this.Valor = valor;
    }
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }
    public bool Pago { get; set; }
    public int PessoaId { get; set; }





}