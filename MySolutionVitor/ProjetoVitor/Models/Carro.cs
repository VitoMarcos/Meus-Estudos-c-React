using System.ComponentModel.DataAnnotations;

namespace Carros.Models;

public class Carro{

public Carro(){
Id = Guid.NewGuid().ToString();
Em = DateTime.Now;
}

public Carro(string marca, string modelo, int ano){
Id = Guid.NewGuid().ToString();
Marca = marca;
Modelo = modelo;
Ano = ano;
Em = DateTime.Now;
}

public string Id {get; set;}
[Required(ErrorMessage = "Este campo é obrigatório!")]
public string? Marca { get; set; }

public string? Modelo { get; set; }

public int Ano { get; set; }

public DateTime Em {get; set;}






}
