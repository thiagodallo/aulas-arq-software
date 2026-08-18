namespace exercicios_apirest.Models;

public class veiculo
{
    public int id { get; set; }
    public string placa { get; set; }
    public string modelo { get; set; }
    public int ano { get; set; }
    public int marca_id { get; set; }
    public int quilometragem { get; set; }
}