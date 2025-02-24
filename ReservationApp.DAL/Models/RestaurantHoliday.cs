using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

public partial class RestaurantHoliday
{
    [Key]
    public int HolidayId { get; set; }

    public int RestaurantId { get; set; }

    public DateOnly HolidayDate { get; set; }

    [ForeignKey("RestaurantId")]
    [InverseProperty("RestaurantHolidays")]
    public virtual Restaurant Restaurant { get; set; } = null!;
}
