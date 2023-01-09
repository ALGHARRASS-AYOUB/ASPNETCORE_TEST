using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EXERCICE4.Models;

[Table("Filiere")]
public partial class Filiere
{
    [Key]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
   // [Unicode(false)]
    public string? Name { get; set; }

    //[InverseProperty("Filiere")]
    public virtual ICollection<Etudiant> Etudiants { get; } = new List<Etudiant>();
}
