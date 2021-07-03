namespace CORE.Commands
{
    /// <summary>
    /// Интерфейс для комманд
    /// </summary>
    /// <typeparam name="T">Контекст или параметр передаваемый в команду</typeparam>
    public interface ICommand<T>
    {
        void Execute(T context);
    }
}