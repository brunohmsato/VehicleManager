using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Domain.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória.")]
        [StringLength(7, ErrorMessage = "A placa deve ter 7 caracteres.")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "O número do Renavam é obrigatório.")]
        [StringLength(11, ErrorMessage = "O Renavam deve ter 11 caracteres.")]
        public string Renavam { get; set; }

        [Required(ErrorMessage = "O número do chassi é obrigatório.")]
        [StringLength(17, ErrorMessage = "O número do chassi deve ter 17 caracteres.")]
        public string ChassiNumber { get; set; }

        [Required(ErrorMessage = "O número do motor é obrigatório.")]
        [StringLength(12, ErrorMessage = "O número do motor deve ter 12 caracteres.")]
        public string MotorNumber { get; set; }

        [Required(ErrorMessage = "Informe a marca do veículo.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Informe o modelo do veículo.")]
        public string Model { get; set; }

        public int FuelId { get; set; }

        public int ColorId { get; set; }

        public int CreatedYear { get; set; }

        [Required(ErrorMessage = "O status do veículo é obrigatório.")]
        public bool Status { get; set; }

        public string SelectedFuelDescription { get; set; }
        public string SelectedColorDescription { get; set; }

        public byte[] VehicleImage { get; set; }
    }
}