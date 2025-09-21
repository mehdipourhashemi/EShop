using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.Entities.BaseEntity;

public class BaseEntity
{
    public BaseEntity()
    {
        this.CreateDate = DateTime.Now;
    }
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
