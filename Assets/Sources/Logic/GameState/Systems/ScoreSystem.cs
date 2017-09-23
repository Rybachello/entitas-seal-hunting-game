using Entitas;

public class ScoreSystem : IInitializeSystem
{
    private readonly GameStateContext _gameStateContext;

    public ScoreSystem (Contexts contexts) {
        _gameStateContext = contexts.gameState;
    }

    public void Initialize ( ) {
        _gameStateContext.SetScore(0);
        _gameStateContext.isGameOver = false;
    }
}