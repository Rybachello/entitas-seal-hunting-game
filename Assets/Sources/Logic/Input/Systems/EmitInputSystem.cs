using Entitas;
using UnityEngine;

public sealed class EmitInputSystem : IExecuteSystem, ICleanupSystem
{
    readonly InputContext _context;
    readonly IGroup<InputEntity> _inputs;
    private readonly GameStateContext _gameStateContext;

    public EmitInputSystem (Contexts contexts) {
        _context = contexts.input;
        _gameStateContext = contexts.gameState;
        _inputs = _context.GetGroup(InputMatcher.Input);
    }

    public void Execute ( ) {
        if (_gameStateContext.isGameOver)
            return;
        var input = Input.GetMouseButtonDown(0);

        if (input) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null) {
                var pos = hit.collider.transform.position;
                _context.CreateEntity()
                        .AddInput((int) pos.x / 8, (int) pos.y / 8); //todo: why divide by 8? 
            }
        }
    }

    public void Cleanup ( ) {
        foreach (var e in _inputs.GetEntities()) {
            e.Destroy();
        }
    }
}