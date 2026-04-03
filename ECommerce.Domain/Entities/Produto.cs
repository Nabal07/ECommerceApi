namespace ECommerce.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; } 
    public decimal Preco { get; set; }

    public Produto()
    {
        
    }

    public Produto(string nome, string descricao, decimal preco)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
}