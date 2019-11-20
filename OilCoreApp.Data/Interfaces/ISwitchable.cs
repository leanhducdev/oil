using OilCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
