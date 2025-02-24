using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

[Table("UserAuthProvider")]
public partial class UserAuthProvider
{
    [Key]
    public long AuthId { get; set; }

    public long UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string AuthProvider { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserAuthProviders")]
    public virtual User User { get; set; } = null!;
}
