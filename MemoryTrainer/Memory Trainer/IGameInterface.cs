namespace Memory_Trainer
{
    public interface IGameInterface
    {
        /// <summary>
        /// Функция сохранения игры
        /// </summary>
        void SaveGame();
        /// <summary>
        /// Функция открытия сохраненной игры
        /// </summary>
        void OpenGame();
        /// <summary>
        /// Функция для отображения правил
        /// </summary>
        void ShowRules();
        /// <summary>
        /// Функция для отображения информации об игре
        /// </summary>
        void ShowInfo();
        /// <summary>
        /// Функция для прорисовки поля
        /// </summary>
        void DrawField();
        /// <summary>
        /// Функция проверки завершения игры
        /// </summary>
        /// <returns>true - игра завершена, false - игра продолжается</returns>
        bool IsFinish();
    }
}
