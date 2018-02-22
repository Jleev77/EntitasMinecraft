using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class VelocityMoveSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public VelocityMoveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            entity.ReplacePosition(entity.position.Value + entity.velocity.Value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasVelocity && entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Velocity);
    }
}
