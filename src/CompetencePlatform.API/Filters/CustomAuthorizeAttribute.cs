using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.Enums;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CompetencePlatform.Core.DataAccess;

namespace CompetencePlatform.API.Filters
{
    public sealed class CustomAuthorizeAttribute
    {
        private readonly PermissionEnum _permission;
        private readonly ModuleEnum _module;
        private readonly SystemRoleEnum[] _rol;

        public CustomAuthorizeAttribute(ModuleEnum module, PermissionEnum permission = PermissionEnum.Ver)
        {
            _module = module;
            _permission = permission;
        }

        public CustomAuthorizeAttribute(ModuleEnum module, SystemRoleEnum[] rol, PermissionEnum permission = PermissionEnum.Ver)
        {
            _module = module;
            _rol = rol;
            _permission = permission;
        }

        public CustomAuthorizeAttribute(ModuleEnum module, SystemRoleEnum rol, PermissionEnum permission = PermissionEnum.Ver)
        {
            _module = module;
            _rol.Append(rol);
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                // skip authorization if action is decorated with [AllowAnonymous] attribute              
                var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousFilter>().Any();
                if (allowAnonymous)
                    return;

                // you can also use registered services                
                var userId = context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    var _userService = context.HttpContext.RequestServices.GetService<IUserService>();
                    var user = _userService.Get(int.Parse(userId)).Result;
                    if (user != null)
                    {
                        var isRol = true;
                        if (_rol != null && _rol.Length > 0)
                        {
                            isRol = _rol.Any(x => user.Roles.Any(y => x.ToString().Equals(y.Name)));
                        }
                        if (isRol)
                        {
                            foreach (var rolItem in user.Roles)
                            {
                                var token = rolItem.ConcurrencyStamp;
                                if (token != null)
                                {
                                    var permission = JwtHelper.GetPermissionOfToken(token, _module.ToString());
                                    if (permission != null)
                                    {
                                        if (permission.Actions.Any(x => x == _permission.ToString()))
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                context.Result = new UnauthorizedResult(); ;
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult(); ;
                throw;
            }
        }
    }
}
