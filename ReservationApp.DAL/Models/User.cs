using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

[Index("Email", Name = "UQ__Users__A9D10534E20A3016", IsUnique = true)]
public partial class User
{
    [Key]
    public long UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(320)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [MaxLength(64)]
    public byte[]? PasswordHash { get; set; }

    public DateOnly? Birthdate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [InverseProperty("User")]
    public virtual ICollection<UserAuthProvider> UserAuthProviders { get; set; } = new List<UserAuthProvider>();
}
