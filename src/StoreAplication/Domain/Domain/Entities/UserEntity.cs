using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using static Domain.Common.Enums;

namespace Domain.Entities
{
    public class UserEntity

    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public UserObjectName Name { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 16 caracteres.")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[^\n\r]+$",
        ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una letra minúscula y un dígito.")]
        public UserObjectPassword Password { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public UserObjectEmail Email { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El rol debe tener entre 3 y 30 caracteres.")]
        public UserObjectRole Role { get; set; }

        [Required(ErrorMessage = "El BranchId es obligatorio.")]
        public Guid BranchId { get; set; }

        public virtual BranchEntity BranchEntity { get; set; }

        public UserEntity(UserObjectName name, UserObjectPassword password, UserObjectEmail email, UserObjectRole role, Guid branchId)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = role;
            BranchId = branchId;
        }

       


       
    }
}
