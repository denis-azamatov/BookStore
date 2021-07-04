using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui.MenuFsm.Printers
{
    /// <summary>
    /// Фабрика принтеров
    /// </summary>
    public static class Printer
    {
        public static IPrinter BeautifyPrinter => new BeautifyPrinter();

        public static IPrinter SimplePrinter => new SimplePrinter();
    }
}
