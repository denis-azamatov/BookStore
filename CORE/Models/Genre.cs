using System;

namespace CORE.Models
{
    /// <summary>
    /// Жанр
    /// </summary>
    [Flags]
    public enum Genre
    {
        /// <summary>
        /// Фэнтези
        /// </summary>
        Fantasy = 1,

        /// <summary>
        /// Научная фантастика
        /// </summary>
        Science = 2,

        /// <summary>
        /// Сказки
        /// </summary>
        FairyTale = 4
    }
}
