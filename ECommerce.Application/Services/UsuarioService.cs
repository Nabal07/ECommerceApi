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

    public async Task<List<ViewUsuarioDTO>> ObterTodosAsync()
    {
        var usuarios = await _usuarioRepository.ObterTodosAsync();

        return usuarios.Select(p => new ViewUsuarioDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Pedidos = p.Pedidos
        }).ToList();
    }

    public async Task<ViewUsuarioDTO> ObterPorIdAsync(Guid id)
    {
        var usuario = await  _usuarioRepository.ObterPorIdAsync(id);

        if (usuario == null)
           throw new Exception($"Usuario com o ID {id} não foi encontrado.");
    
        return new ViewUsuarioDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Pedidos = usuario.Pedidos
        };
    }
}

