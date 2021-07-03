using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui.MenuFsm.Results
{
    public class TextInputResult : ExecuteResult
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }
    }
}
