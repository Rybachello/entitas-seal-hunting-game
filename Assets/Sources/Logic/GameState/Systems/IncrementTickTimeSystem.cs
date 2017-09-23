using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IncrementTickTimeSystem : ReactiveSystem<GameStateEntity>
{
    private readonly GameStateContext _context;
    private readonly IGroup<GameEntity> _boardHoleGroup;
    private float spawnInterval = Contexts.sharedInstance.game.globals.value.spawnSealInterval;

    public IncrementTickTimeSystem (Contexts context) : base(context.gameState) {
        _context = context.gameState;
        _boardHoleGroup = context.game.GetGroup(GameMatcher.AllOf(GameMatcher.GameBoardHole));
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

        var timeEntity = _context.deltaTimeEntity;
        var currentSpawnTick = timeEntity.hasSpawnTime ? timeEntity.spawnTime.value : 0;
        currentSpawnTick += timeEntity.deltaTime.value;
        var tickInterval = Contexts.sharedInstance.game.globals.value.spawnSealInterval;
        if (currentSpawnTick > tickInterval) {
            currentSpawnTick = 0;
            UpdateSpawnInterval();
            FindFreeHole();
        }
        timeEntity.ReplaceSpawnTime(currentSpawnTick);
    }

    private void UpdateSpawnInterval ( ) {
        spawnInterval *= 0.85f;
        if (spawnInterval < 0.5)
            spawnInterval = 0.5f;
    }

    private void FindFreeHole ( ) {
        var freeHoles = _boardHoleGroup.GetEntities().Where(hole => hole.isBusyBoard == false).ToList();
        var freeHole = freeHoles[Random.Range(0, freeHoles.Count())];
        if (freeHole.isBusyBoard == false) {
            freeHole.isBusyBoard = true;
        }
    }
}