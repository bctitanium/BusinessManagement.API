using BusinessManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.API.DTOs
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<RoleDTO>))]
    public class RoleDTO : BaseDTO<string>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
