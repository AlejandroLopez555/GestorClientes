using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionClientes.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15, ErrorMessage = "El teléfono no puede exceder 15 caracteres")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El vehículo es obligatorio")]
        [StringLength(50, ErrorMessage = "El vehículo no puede exceder 50 caracteres")]
        [Display(Name = "Modelo del Vehículo")]
        public string Vehiculo { get; set; }

        [Required(ErrorMessage = "El tipo de vehículo es obligatorio")]
        [Display(Name = "Tipo de Vehículo")]
        public string TipoVehiculo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

    // Clase para las opciones de tipo de vehiculo
    public static class TiposVehiculo
    {
        public const string Sedan = "Sedan";
        public const string Coupe = "Coupe";
        public const string Deportivo = "Deportivo";
        public const string Hatchback = "Hatchback";
        public const string SUV = "SUV";
        public const string PickUp = "PickUp";

        public static List<string> ObtenerTodos()
        {
            return new List<string> { Sedan, Coupe, Deportivo, Hatchback, SUV, PickUp };
        }
    }
}