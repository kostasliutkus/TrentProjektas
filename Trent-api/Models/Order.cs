﻿using System.ComponentModel.DataAnnotations.Schema;

namespace T_rent_api.Models;

public class Order
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("creation_date")]
    public DateTime CreationDate { get; set; }
    
    [Column("lease_start_date")]
    public DateTime LeaseStartDate { get; set; }
    
    [Column("lease_expiration_date")]
    public DateTime LeaseEndDate { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }
    [Column("fk_accommodation_id")]
    public decimal AccommodationID { get; set; }
}