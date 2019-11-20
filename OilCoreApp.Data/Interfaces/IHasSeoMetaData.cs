using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTittle { get; set; }
        string SeoAlias { get; set; }
        string SeoKeywords { get; set; }
        string SeoDescriptions { get; set; }
    }
}
