using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

public class AddViewFromPrefabSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Transform _transform;

    public AddViewFromPrefabSystem(Contexts contexts, Transform transform) : base(contexts.game)
    {
        _contexts = contexts;
        _transform = transform;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var blockPrefab = Resources.Load<GameObject>(entity.prefab.Name);
            var block = UnityEngine.Object.Instantiate(blockPrefab, _transform);

            entity.AddView(block);
            block.Link(entity);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPrefab && !entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Prefab);
    }
}
