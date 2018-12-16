using System.Collections.Generic;
using System.Windows.Controls;

namespace SweetsFactory.Classes.CPermission
{   
    public class Permission
    {
        public bool Permitted { get; set; } = false;
        public ulong IDFunc { get; set; } = 0; 
        List<Permission> childPermissions = null;
        public List<Permission> ChildPermissions { get => childPermissions; set {
                if (value != null) {
                    value.ForEach((x) =>
                        {
                            x.FatherPermission = this;
                        });
                    childPermissions = value;
                }
            }
        }
        public Permission FatherPermission = null;
        public string Tittle { get; set; }
    }
}
