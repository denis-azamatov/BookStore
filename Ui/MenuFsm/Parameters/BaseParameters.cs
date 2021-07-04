using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui.MenuFsm.Parameters
{
    /// <summary>
    /// Параметр для вызова состояния
    /// </summary>
    public class BaseParameters
    {
        public string Header { get; set; }

        public Guid Id { get; set; }
    }
}
