using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;

namespace Ui.MenuFsm.Printers
{
    public class SimplePrinter : IPrinter
    {
        public string Print(Book book)
        {
            return $"{book.Content}";
        }
    }
}
