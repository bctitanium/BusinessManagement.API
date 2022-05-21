using BusinessManagement.Core.UserIdentify;
using BusinessManagement.API.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Validators
{
    public class RoleValidator : AbstractValidator<RoleDTO>
    {
        public RoleValidator(RoleManager<Role> roleManager)
        {
            RuleFor(r => r.Name).MustAsync((role, name, _) => roleManager.Roles.AllAsync(r => r.Id == role.Id || r.NormalizedName != roleManager.NormalizeKey(name))).WithMessage("{PropertyName} is duplicated");
        }
    }
}
