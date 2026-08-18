using Microsoft.AspNetCore.Mvc;
using exercicios_apirest.Models;

namespace exercicios_apirest.Controllers;

[ApiController]
[Route("api/veiculos")]
public class veiculos_controller : ControllerBase
{
    public static List<veiculo> lista_veiculos = new();
    private static int proximo_id = 1;

    [HttpGet]
    public IActionResult listar()
    {
        return Ok(lista_veiculos);
    }

    [HttpGet("{id}")]
    public IActionResult buscar_por_id(int id)
    {
        var veiculo_encontrado = lista_veiculos.FirstOrDefault(v => v.id == id);

        if (veiculo_encontrado == null)
            return NotFound();

        return Ok(veiculo_encontrado);
    }

    [HttpPost]
    public IActionResult inserir(veiculo novo_veiculo)
    {
        var marca_encontrada = marcas_controller.lista_marcas.FirstOrDefault(m => m.id == novo_veiculo.marca_id);

        if (marca_encontrada == null)
            return BadRequest("Marca não encontrada.");

        if (!marca_encontrada.ativa)
            return BadRequest("Marca inativa.");

        novo_veiculo.id = proximo_id;
        proximo_id++;

        lista_veiculos.Add(novo_veiculo);

        return CreatedAtAction(nameof(buscar_por_id), new { id = novo_veiculo.id }, novo_veiculo);
    }

    [HttpPut("{id}")]
    public IActionResult editar(int id, veiculo veiculo_atualizado)
    {
        var veiculo_existente = lista_veiculos.FirstOrDefault(v => v.id == id);

        if (veiculo_existente == null)
            return NotFound();

        var marca_encontrada = marcas_controller.lista_marcas.FirstOrDefault(m => m.id == veiculo_atualizado.marca_id);

        if (marca_encontrada == null)
            return BadRequest("Marca não encontrada.");

        if (!marca_encontrada.ativa)
            return BadRequest("Marca inativa.");

        veiculo_existente.placa = veiculo_atualizado.placa;
        veiculo_existente.modelo = veiculo_atualizado.modelo;
        veiculo_existente.ano = veiculo_atualizado.ano;
        veiculo_existente.marca_id = veiculo_atualizado.marca_id;
        veiculo_existente.quilometragem = veiculo_atualizado.quilometragem;

        return Ok(veiculo_existente);
    }

    [HttpDelete("{id}")]
    public IActionResult excluir(int id)
    {
        var veiculo_existente = lista_veiculos.FirstOrDefault(v => v.id == id);

        if (veiculo_existente == null)
            return NotFound();

        lista_veiculos.Remove(veiculo_existente);

        return Ok();
    }

    [HttpPatch("{id}/quilometragem")]
    public IActionResult atualizar_quilometragem(int id, request_atualizarkm request)
    {
        var veiculo_existente = lista_veiculos.FirstOrDefault(v => v.id == id);

        if (veiculo_existente == null)
            return NotFound();

        veiculo_existente.quilometragem = request.nova_quilometragem;

        return Ok(veiculo_existente);
    }
}