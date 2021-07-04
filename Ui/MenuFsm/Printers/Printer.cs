using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui.MenuFsm.Printers
{
    public static class Printer
    {
        public static IPrinter BeautifyPrinter => new BeautifyPrinter();

        public static IPrinter SimplePrinter => new SimplePrinter();
    }
}
