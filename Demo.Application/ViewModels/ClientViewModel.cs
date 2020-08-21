using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Application.ViewModels
{
    public class ClientViewModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Minimo {0} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório")]
        [StringLength(1, ErrorMessage = "Deve conter {0} caracteres")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [StringLength(8, ErrorMessage = "Deve conter {0} caracteres")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Minimo {0} caracteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Minimo {0} caracteres")]
        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string District { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string State { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string City { get; set; }
    }
}
