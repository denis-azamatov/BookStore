namespace CORE.Commands.BookCommands
{
    /// <summary>
    /// Комманда добавления книг в каталог клиента и удаления из корзины
    /// </summary>
    public class AddBookToUserCommand : ICommand<object>
    {
        public void Execute(object context)
        {
            Storage.Instance.AddBookToUser();
        }
    }
}
