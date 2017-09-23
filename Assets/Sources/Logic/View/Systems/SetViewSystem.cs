using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class SetViewSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;
    private readonly Globals _globals = Contexts.sharedInstance.game.globals.value;

    public SetViewSystem (ICollector<GameEntity> collector) : base(collector) {
    }

    public SetViewSystem (Contexts context) : base(context.game) {
        _context = context.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Position));
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            var position = new IntVector2(
                entity.position.value.x * _globals.width,
                entity.position.value.y * _globals.height);
            entity.view.gameObject.transform.position = new Vector3(position.x, position.y, 0f);
        }
    }
}