namespace Memory_Trainer
{
    public interface IGameInterface
    {
        void SaveGame();
        void OpenGame();
        void ShowRules();
        void ShowInfo();
        void DrawField();
        bool IsFinish();
    }
}
