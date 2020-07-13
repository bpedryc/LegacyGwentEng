using System;
using System.Collections.Generic;
using System.Text;

namespace Cynthia.Card.Common.Models
{
    public interface ITranslator
    {
        string GetText(string id);
    }
}
