
using System.Windows.Controls;
using SweetsFactory.Classes.Bases.CBaseFactory;
using SweetsFactory.Classes.Bases.CBasePosads;
using SweetsFactory.Classes.Bases.CBasePermissions;
using SweetsFactory.Classes.CPosada;
using System.Collections.Generic;
using SweetsFactory.Pages;
namespace SweetsFactory.VVARS
{
    

    static class VARS {
        public delegate void OnChange();
        public static event OnChange onChangeCurrentPage;
        public static event OnChange onChangeCurrentLoginPage;
        public static Classes.CWorkPerson.WorkPerson currentUser;
        static Page currentPage;
        static Page currentLoginPage;
        public static MainWindow mainWnd;
        public static Page CurrentPage {
            get => currentPage;
            set
            {
                currentPage = value;
                onChangeCurrentPage?.Invoke();
            }
        }
        public static Page CurrentLoginPage
        {
            get => currentLoginPage;
            set
            {
                currentLoginPage = value;
                onChangeCurrentLoginPage?.Invoke();
            }
        }
        public static List<Page> pages;
        public static List<Page> loginPages;
        public static BaseFactory factory;

        static VARS(){
            // Pages

            pages = new List<Page>();
            pages.Add(new Pages.Login());
            pages.Add(new Pages.AllovedLogin());

            loginPages = new List<Page>();
            loginPages.Add(new Pages.EditWorker.EditPassword());

            currentPage = pages[(int)PegesEnumeration.Login];



            //pages.ForEach((x) =>
            //{
            //    x.ShowsNavigationUI = false;
            //});
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
