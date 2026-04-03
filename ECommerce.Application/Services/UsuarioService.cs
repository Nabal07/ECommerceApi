using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Interfaces.Repositories;

namespace ECommerce.Application.Services;

public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<ViewUsuarioDTO>> ObterTodos()
    {
        var usuarios = await _usuarioRepository.ObterTodos();

        return usuarios.Select(p => new ViewUsuarioDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Pedidos = p.Pedidos
        }).ToList();
    }

    public async Task<ViewUsuarioDTO> ObterPorId(Guid id)
    {
        var usuarios = await  _usuarioRepository.ObterPorId(id);

        var usuario = usuarios.FirstOrDefault();

        if (usuario == null)
        {
            throw new Exception($"Usuario com o ID {id} não foi encontrado.");
        }

        return new ViewUsuarioDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Pedidos = usuario.Pedidos
        };
    }
}

