using SweetsFactory.Classes.CPosada;
using System.Collections.Generic;


namespace SweetsFactory.Classes.Bases.CBasePosads
{
    public static class BasePosadas
    {
        static List<Posada> posads = new List<Posada>();

        // MainFunctions

        public static void AddPosada(Posada posada)
        {
            posads.Add(posada);
        }

        public static bool RemovePosada(ref Posada posada)
        {
            return posads.Remove(posada);
        }

        public static ref List<Posada> GetPosads()
        {
            return ref posads;
        }

        
    }
}
