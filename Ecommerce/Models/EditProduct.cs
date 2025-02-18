using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public class EditProduct
{
    public Guid? Id { get; set; }
    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Il nome è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string? Name { get; set; }

    [Display(Name = "Product description")]
    [StringLength(500, ErrorMessage = "La descrizione non può superare i 500 caratteri.")]
    public string? Description { get; set; }

    [Display(Name = "Product category")]
    [Required(ErrorMessage = "Selezionare una categoria.")]
    public Guid CategoryId { get; set; }

    [Display(Name = "Product price")]
    [Required(ErrorMessage = "Il prezzo è obbligatorio.")]
    [Range(0.01, 100000, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 e 100000.")]
    public decimal Price { get; set; }
    
    public List<Category>? Categories { get; set; }
}