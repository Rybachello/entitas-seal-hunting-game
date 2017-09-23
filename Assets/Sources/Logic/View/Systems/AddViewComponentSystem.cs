using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Resources = UnityEngine.Resources;

public class AddViewComponentSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _viewContainer = new GameObject("Views").transform;
    private GameContext _context;

    public AddViewComponentSystem (ICollector<GameEntity> collector) : base(collector) {
    }

    public AddViewComponentSystem (Contexts context) : base(context.game) {
        _context = context.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute (List<GameEntity> entities) {
        int i = 0;
        foreach (var e in entities) {
            var asset = UnityEngine.Resources.Load(e.asset.name) as GameObject;
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(asset);
                gameObject.name = e.asset.name + "_" + i;
            } catch (Exception) {
                Debug.Log("Cannot instantiate " + e.asset.name);
            }
            if (gameObject == null)
                return;
            switch (e.asset.name) {
                case Res.Hole:
                    gameObject.transform.SetParent(_viewContainer, false);
                    break;
                case Res.Seal:
                    gameObject.transform
                              .DOLocalMove(Vector3.up * 0.5f, 0.5f);
                    var parent = _context.GetEntitiesWithPosition(e.position.value)
                                         .First().view.gameObject.transform;
                    var spriteRenderer = gameObject.GetComponent<SpriteRenderer>() ??
                                         gameObject.AddComponent<SpriteRenderer>();

                    var sealSprites = _context.globals.value.SealSprites;

                    spriteRenderer.sprite = sealSprites[UnityEngine.Random.Range(0, sealSprites.Length)];
                    gameObject.AddComponent<BoxCollider2D>();
                    gameObject.transform.SetParent(parent, false);
                    break;
            }
            e.AddView(gameObject);
            gameObject.Link(e, _context);
            i++;
        }
    }
}