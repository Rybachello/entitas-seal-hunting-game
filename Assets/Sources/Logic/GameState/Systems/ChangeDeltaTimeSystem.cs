using Entitas;
using UnityEngine;

public class ChangeDeltaTimeSystem : IExecuteSystem
{
    private readonly GameStateContext _context;

    public ChangeDeltaTimeSystem (Contexts contexts) {
        _context = contexts.gameState;
    }

    public void Execute ( ) {
        if (_context.isGameOver)
            return;
        _context.ReplaceDeltaTime(Time.deltaTime);
    }
}