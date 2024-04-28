using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Domain.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição da cor é obrigatória.")]
        [StringLength(20, ErrorMessage = "A descrição deve ter no máximo 20 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O status da cor é obrigatório.")]
        public bool Status { get; set; }
    }
}