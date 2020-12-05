using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefonszamok_DAL;

namespace Telefonszamok_LA01
{
   public static class Bovito
    {
        public static string Telefonszamok(this enSzemely enSzemely)
        {
            var s = "";
            foreach (var x in enSzemely.enTelefonszam)
            {
                s = s + x.Szam;
                if (x != enSzemely.enTelefonszam.Last()) s = s + ", ";
            }
            return s;
        }
    }
}
