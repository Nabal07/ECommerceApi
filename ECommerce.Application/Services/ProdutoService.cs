using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Interfaces.Repositories;

namespace ECommerce.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<ViewProdutoDTO>> ObterTodos()
    {
        var produtos = await _produtoRepository.ObterTodos();

        return produtos.Select(p => new ViewProdutoDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco,
        }).ToList();
    }

    public async Task<ViewProdutoDTO> ObterPorId(Guid id)
    {
        var produtos = await _produtoRepository.ObterPorId(id);

        var produto = produtos.FirstOrDefault();

        if (produto == null)
        {
            throw new Exception($"Produto com o ID {id} não foi encontrado.");
        }

        return new ViewProdutoDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
        };
    }
}