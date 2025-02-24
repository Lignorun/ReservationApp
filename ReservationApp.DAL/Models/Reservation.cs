using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

[Table("Reservation")]
public partial class Reservation
{
    [Key]
    public long ReservationId { get; set; }

    public long UserId { get; set; }

    public int RestaurantId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(320)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime ReservationDate { get; set; }

    public int PeopleCount { get; set; }

    public byte? Status { get; set; }

    public bool? HiddenFromUser { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("RestaurantId")]
    [InverseProperty("Reservations")]
    public virtual Restaurant Restaurant { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reservations")]
    public virtual User User { get; set; } = null!;
}
