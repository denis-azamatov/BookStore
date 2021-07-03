namespace BookStore.Commands
{
    /// <summary>
    /// Интерфейс для комманд
    /// </summary>
    /// <typeparam name="T">Контекст или параметр передаваемый в команду</typeparam>
    public interface ICommand<T>
    {
        public string Name { get; }
        void Execute(T context);
    }
}