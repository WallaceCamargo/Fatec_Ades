using System.ComponentModel.DataAnnotations;

namespace front_end.Models;

public class CategoriaViewModel
{

    public int CategoriaId { get; set; }
    [Required(ErrorMessage ="O nome da categoria é obrigatorio")]
    public string? Nome { get; set; }
    [Required]
    [Display(Name = "Imagem")]
    public string? ImagemUrl { get; set; }

}
