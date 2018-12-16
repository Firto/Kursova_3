using System.Collections.Generic;
using SweetsFactory.Classes.CWorkPerson;
using SweetsFactory.Classes.CSecurity;

namespace SweetsFactory.Classes.Bases.CBaseFactory
{
    public class BaseFactory
    {
        List<WorkPerson> workers = new List<WorkPerson>();

        // MainFunctions

        public void AddWorkPerson(WorkPerson workPerson) {
            workers.Add(workPerson);
        }

        public bool RemoveWorkPerson(ref WorkPerson workPerson) {
            return workers.Remove(workPerson);
        }

        public ref List<WorkPerson> GetWorksPersons() {
            return ref workers;
        }

        public WorkPerson IsIssetUser(string Login)
        {
            return workers.Find((x) => x.UserName == Login);
        }
    }
}
