using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXERCICE4.Models;

namespace EXERCICE4.Services
{
   public  interface IEtudiantService
    {
       public  void Save(Etudiant e);

      public   IEnumerable<Etudiant> FindAll();

       public  Etudiant GetEtudiantById(int? id);
        
    }
}
