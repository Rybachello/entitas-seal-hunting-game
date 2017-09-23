using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public sealed class DestroySystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public DestroySystem (Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.isDestroyed;
    }

    protected override void Execute (List<GameEntity> entities) {
        entities.ForEach(e => e.Destroy());
    }
}