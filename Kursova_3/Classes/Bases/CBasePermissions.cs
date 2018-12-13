using System.Collections.Generic;
using SweetsFactory.Classes.CPermission;

namespace SweetsFactory.Classes.Bases.CBasePermissions
{
    public static class ProffilePermissions
    {
        public static Permission GetPerms() => new Permission
        {
            Permitted = true,
            Tittle = "Налаштування",
            childPermissions = new List<Permission>
            {
                new Permission{
                    Permitted = true,
                    Tittle = "Змінити логін",
                },
                new Permission{
                    Permitted = true,
                    Tittle = "Змінити пароль",
                },
                new Permission{
                    Permitted = true,
                    Tittle = "Змінити пошту",
                }
            }
        };
    }

    public static class BasePermissions
    {
        public static Permission GetPerms() => new Permission
        {
            Permitted = true,
            Tittle = "Головна",
            childPermissions = new List<Permission>
            {
                ProffilePermissions.GetPerms()
            }
        };
    }
}
