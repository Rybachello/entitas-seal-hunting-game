using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class DecrementTimeLeftSystem : ReactiveSystem<GameStateEntity>, IInitializeSystem
{
    private readonly GameStateContext _context;

    public DecrementTimeLeftSystem (Contexts context) : base(context.gameState) {
        _context = context.gameState;
    }

    protected override ICollector<GameStateEntity> GetTrigger (IContext<GameStateEntity> context) {
        return context.CreateCollector(GameStateMatcher.DeltaTime);
    }

    protected override bool Filter (GameStateEntity entity) {
        return entity.hasDeltaTime;
    }

    protected override void Execute (List<GameStateEntity> entities) {
        if (_context.isGameOver)
            return;

        var deltaTimeEntity = _context.deltaTimeEntity;
        var currentTimeLeft = _context.timeLeftEntity.timeLeft.value - deltaTimeEntity.deltaTime.value;
        
        if (currentTimeLeft < 0) {
            _context.isGameOver = true; 
            return;
        }

        _context.timeLeftEntity.ReplaceTimeLeft(currentTimeLeft);
    }

    public void Initialize ( ) {
        var totalTime = Contexts.sharedInstance.game.globals.value.totalTime;
        _context.SetTimeLeft(totalTime);
    }
}