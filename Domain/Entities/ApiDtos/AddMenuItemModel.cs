using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiDtos
{
    public record AddMenuItemModel(string foodName,decimal price,DateTime cooockingTime,string ResturantID);
}
