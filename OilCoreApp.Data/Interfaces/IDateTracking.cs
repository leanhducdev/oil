using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { get; set; }
        DateTime Modified { get; set; }
    }
}
