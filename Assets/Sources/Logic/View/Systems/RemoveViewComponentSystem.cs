using Entitas;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas.Unity;
using UnityEngine;

public class RemoveViewComponentSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;

    public RemoveViewComponentSystem (ICollector<GameEntity> collector) : base(collector) {
    }

    public RemoveViewComponentSystem (Contexts context) : base(context.game) {
        _context = context.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Destroyed,GameMatcher.View));
    }

    protected override bool Filter (GameEntity entity) {
        return entity.isDestroyed && entity.hasView;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            var holeEntity = Contexts.sharedInstance.game.GetEntitiesWithPosition(entity.position.value).First();
            holeEntity.isBusyBoard = false;
            DeleteSealEntity(entity.view);
        }
    }

    private void DeleteSealEntity(ViewComponent viewComponent)
    {
        var gameObject = viewComponent.gameObject;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.material.DOColor(color, 0.5f);
        gameObject.Unlink();
        gameObject.transform
                  .DOLocalMove(Vector3.down * 1.5f, 0.5f)
                  .OnComplete(() => {
                      Object.Destroy(gameObject);
                  });
    }
}