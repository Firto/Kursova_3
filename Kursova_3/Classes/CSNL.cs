using System;
using System.Text.RegularExpressions;

namespace SweetsFactory.Classes.CSNL { 
    public class SNLExpression : Exception
    {
        public SNLExpression(string message) : base(message) { }
    }
    public class SNL
    {
        string name,
               sername,
               lastname;

        public void IsOkSNL_Str(string str)
        {
            if (!Regex.IsMatch(str, @"^([А-Яа-яi][а-я'і]+)$")) throw new SNLExpression("Incorrect SNL string"); 
        }

        public string Lastname
        {
            get => lastname;
            set{
                IsOkSNL_Str(value);
                lastname = value;
            }
        }

        public string Sername
        {
            get => sername;
            set{
                IsOkSNL_Str(value);
                sername = value;
            }
        }

        public string Name
        {
            get => name;
            set{
                IsOkSNL_Str(value);
                name = value;
            }
        }
    }
}
