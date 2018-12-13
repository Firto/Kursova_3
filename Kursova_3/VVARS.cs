
using System.Windows.Controls;
namespace SweetsFactory.VVARS
{
    using SweetsFactory.Classes.Bases.CBaseFactory;
    using SweetsFactory.Classes.Bases.CBasePosads;
    using SweetsFactory.Classes.Bases.CBasePermissions;
    using SweetsFactory.Classes.CPosada;
    using System.Collections.Generic;
    using SweetsFactory.Pages;

    static class VARS {
        public delegate void OnChange();
        public static OnChange onChangeCurrentPage;
        static Page currentPage;
        public static Page CurrentPage {
            get => currentPage;
            set
            {
                currentPage = value;
                onChangeCurrentPage?.Invoke();
            }
        }
        public static List<Page> pages;
        public static BaseFactory factory;

        static VARS(){
            // Pages

            pages = new List<Page>();
            pages.Add(new Pages.Login());
            currentPage = pages[(int)PegesEnumeration.Login];

            // Ініціалізуєм массив прцівників

            factory = new BaseFactory();

            // Init Admin Posada

            BasePosadas.AddPosada(new Posada {
                MustWork = "Слідкувати за базою данних!",
                Salary = 1000000,
                Tittle = "Адмін",
                perm = BasePermissions.GetPerms()
            });

            // Добавляєм Адміна

            factory.AddWorkPerson(
                new Classes.CWorkPerson.WorkPerson
                {
                    Age = 15,
                    Birthday = new Classes.CBirthdayDate.BDate(2003, 8, 29),
                    Password = "admin",
                    Email = "profliste@gmail.com",
                    FName = new Classes.CSNL.SNL {
                        Name = "Сергій",
                        Lastname = "Степанчук",
                        Sername = "Тарасович"
                    },
                    UserName = "admin",
                    Posada = BasePosadas.GetPosads()[0]
                }
            );
        }
    }
}
