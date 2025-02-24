using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.DAL.Models;

public partial class RestaurantOpenDay
{
    [Key]
    public int OpenDayId { get; set; }

    public int RestaurantId { get; set; }

    public byte WeekDay { get; set; }

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    [ForeignKey("RestaurantId")]
    [InverseProperty("RestaurantOpenDays")]
    public virtual Restaurant Restaurant { get; set; } = null!;
}
