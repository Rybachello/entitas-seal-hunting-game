using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class AddSealSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddSealSystem (Contexts context) : base(context.game) {
        _context = context.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.BusyBoard);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.isBusyBoard;
    }

    protected override void Execute (List<GameEntity> entities) {
        entities.ForEach(CreateSeal);
    }

    private void CreateSeal (GameEntity entity) {
        var position = entity.position.value;
        var sealEntity = _context.CreateEntity();
        sealEntity.AddSeal(5);
        sealEntity.AddPosition(position);
        sealEntity.AddAsset(Res.Seal);
    }
}