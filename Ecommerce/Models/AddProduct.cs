using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public class AddProduct
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La descrizione non può superare i 500 caratteri.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Selezionare una categoria.")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range(0.01, 100000, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 e 100000.")]
    public decimal Price { get; set; }

    public List<Category>? Categories { get; set; } // Per popolare la select
}