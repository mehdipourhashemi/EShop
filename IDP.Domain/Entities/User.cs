using IDP.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.Entities;

public class User : BaseEntity.BaseEntity
{
    public required string FullName { get; set; }
    public required string CodeNumber { get; set; }
}