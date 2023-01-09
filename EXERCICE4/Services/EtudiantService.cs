using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXERCICE4.Models;
using Microsoft.EntityFrameworkCore;

namespace EXERCICE4.Services
{
    public class EtudiantService: IEtudiantService
    {
        private readonly StudentsDbContext _context;

        public EtudiantService(StudentsDbContext context)
        {
            this._context = context;
        }

        public void Save(Etudiant e)
        {
            _context.Etudiants.Add(e);
            _context.SaveChanges();

        }

       public  IEnumerable<Etudiant> FindAll()
        {
         
                         
            return _context.Etudiants;
        }

       public  Etudiant GetEtudiantById(int? id) 
        {
            if (id == null || _context.Etudiants == null)
            {
                return null;
            }

            Etudiant etudiant =  _context.Etudiants
                .Include(e => e.Filiere)
                .First(m => m.Id == id);
            if (etudiant == null)
            {
                return null;
            }
            return etudiant;
        }

    }
}
