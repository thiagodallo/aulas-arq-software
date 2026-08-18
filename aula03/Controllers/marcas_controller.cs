using Microsoft.AspNetCore.Mvc;
using exercicios_apirest.Models;

namespace exercicios_apirest.Controllers;

[ApiController]
[Route("api/marcas")]
public class marcas_controller : ControllerBase
{
    public static List<marca> lista_marcas = new();
    private static int proximo_id = 1;

    [HttpGet]
    public IActionResult listar()
    {
        return Ok(lista_marcas);
    }

    [HttpGet("{id}")]
    public IActionResult buscar_por_id(int id)
    {
        var marca_encontrada = lista_marcas.FirstOrDefault(m => m.id == id);

        if (marca_encontrada == null)
            return NotFound();

        return Ok(marca_encontrada);
    }

    [HttpPost]
    public IActionResult inserir(marca nova_marca)
    {
        nova_marca.id = proximo_id;
        proximo_id++;

        lista_marcas.Add(nova_marca);

        return CreatedAtAction(nameof(buscar_por_id), new { id = nova_marca.id }, nova_marca);
    }

    [HttpPut("{id}")]
    public IActionResult editar(int id, marca marca_atualizada)
    {
        var marca_existente = lista_marcas.FirstOrDefault(m => m.id == id);

        if (marca_existente == null)
            return NotFound();

        marca_existente.nome = marca_atualizada.nome;
        marca_existente.ativa = marca_atualizada.ativa;

        return Ok(marca_existente);
    }

    [HttpDelete("{id}")]
    public IActionResult excluir(int id)
    {
        var marca_existente = lista_marcas.FirstOrDefault(m => m.id == id);

        if (marca_existente == null)
            return NotFound();

        lista_marcas.Remove(marca_existente);

        return Ok();
    }
}