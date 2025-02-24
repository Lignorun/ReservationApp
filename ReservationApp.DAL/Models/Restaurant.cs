using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

[Table("Restaurant")]
public partial class Restaurant
{
    [Key]
    public int RestaurantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [InverseProperty("Restaurant")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [InverseProperty("Restaurant")]
    public virtual ICollection<RestaurantHoliday> RestaurantHolidays { get; set; } = new List<RestaurantHoliday>();

    [InverseProperty("Restaurant")]
    public virtual ICollection<RestaurantOpenDay> RestaurantOpenDays { get; set; } = new List<RestaurantOpenDay>();
}
