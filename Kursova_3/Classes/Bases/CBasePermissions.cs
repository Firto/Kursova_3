using System.Collections.Generic;
using SweetsFactory.Classes.CPermission;

namespace SweetsFactory.Classes.Bases.CBasePermissions
{
    public static class ProffilePermissions
    {
        public static Permission GetPerms() => new Permission
        {
            Permitted = true,
            Tittle = "Налаштування профілю",
            
            ChildPermissions = new List<Permission>
            {
                new Permission{
                    Permitted = true,
                    IDFunc = 1,
                    Tittle = "Змінити логін",
                },
                new Permission{
                    Permitted = true,
                    IDFunc = 2,
                    Tittle = "Змінити пароль",
                },
                new Permission{
                    Permitted = true,
                    IDFunc = 3,
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
            ChildPermissions = new List<Permission>
            {
                ProffilePermissions.GetPerms()
            }
        };
    }
}
