﻿using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.Entities.Base;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
