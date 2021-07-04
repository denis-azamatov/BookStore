using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ui.MenuFsm
{
    /// <summary>
    /// Состояния интерфейса
    /// </summary>
    public enum State
    {
        None,

        MainMenu,

        BookCatalog,
        BookMenu,
        AddToBucket,
        CommentCatalog,
        CommentInput,
        AddComment,
        Preview,

        BucketCatalog,
        AddToUser,

        UserCatalog,
        UserBookMenu,
        BeautifyPrint,
        SimplePrint,
        PrintOutput
    }
}
