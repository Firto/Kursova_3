using System.Collections.Generic;

namespace SweetsFactory.Classes.CPermission
{   
    public class Permission
    {
        public bool Permitted { get; set; } = false;
        public List<Permission> childPermissions { get; set; }
        public string Tittle { get; set; }
    }
}
