using SweetsFactory.Classes.CPermission;
using System.Collections.Generic;
namespace SweetsFactory.Classes.CPosada
{
    public class Posada
    {
        public Permission perm { get; set; } // Дозволи
        public uint Salary { get; set; } // Зарплата
        public string Tittle { get; set; } // Назва Посади
        public string MustWork { get; set; } // Що Має Робити
        List<Posada> childPosadas { get; set; } // Для ієрархії посад
    }

    
}
