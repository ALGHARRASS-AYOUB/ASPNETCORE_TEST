using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EXERCICE4.Models;

[Table("Etudiant")]
public partial class Etudiant
{
    [Key]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("filiere_id")]
    public int? FiliereId { get; set; }

    [ForeignKey("FiliereId")]
    //[InverseProperty("Etudiants")]
    public virtual Filiere? Filiere { get; set; }
}
