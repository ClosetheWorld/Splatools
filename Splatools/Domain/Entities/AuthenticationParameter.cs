using System;
using System.ComponentModel.DataAnnotations;

namespace Splatools.Domain.Entities;

public class AuthenticationParameter
{
    [Key]
    public Guid Key { get; set; }
    
    [MaxLength(52)]
    public string Challenge { get; set; }
    
    public long InsertionTime { get; set; }
}