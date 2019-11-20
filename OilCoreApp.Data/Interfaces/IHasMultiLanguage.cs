using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.Interfaces
{
    public interface IHasMultiLanguage<T>
    {
        T LanguageId { get; set; }
    }
}
