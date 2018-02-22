using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderMaterialComponent : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public RenderMaterialComponent(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.GameObject.GetComponent<Renderer>().material = Resources.Load<Material>(entity.material.Name);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMaterial && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Material, GameMatcher.View));
    }
}
