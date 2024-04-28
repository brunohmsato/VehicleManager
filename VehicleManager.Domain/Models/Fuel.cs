using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Domain.Models
{
    public class Fuel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição do combustível é obrigatória.")]
        [StringLength(20, ErrorMessage = "A descrição deve ter no máximo 20 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O status do combustível é obrigatório.")]
        public bool Status { get; set; }
    }
}