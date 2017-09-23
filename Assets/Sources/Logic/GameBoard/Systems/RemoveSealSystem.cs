using Entitas;
using System.Collections.Generic;
using System.Linq;
using Entitas.Unity;
using UnityEngine;

public class RemoveSealSystem : ReactiveSystem<GameStateEntity>
{
    private readonly GameStateContext _context;
    private readonly IGroup<GameEntity> _sealsGroup;

    public RemoveSealSystem (Contexts context) : base(context.gameState) {
        _context = context.gameState;
        _sealsGroup = context.game.GetGroup(GameMatcher.Seal);
    }

    protected override ICollector<GameStateEntity> GetTrigger (IContext<GameStateEntity> context) {
        return context.CreateCollector(GameStateMatcher.DeltaTime);
    }

    protected override bool Filter (GameStateEntity entity) {
        return entity.hasDeltaTime;
    }

    protected override void Execute (List<GameStateEntity> entities) {
        var deltaTime = _context.deltaTimeEntity.deltaTime;
        foreach (var entity in _sealsGroup.GetEntities()) {
            var currentTime = entity.seal.timeLeft;
            currentTime -= deltaTime.value;

            entity.ReplaceSeal(currentTime);
            if (entity.seal.timeLeft <= 0) {
                entity.isDestroyed = true;
            }
        }
    }
}