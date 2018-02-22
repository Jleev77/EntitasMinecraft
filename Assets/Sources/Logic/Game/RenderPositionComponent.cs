using System.Collections.Generic;
using Entitas;

public class RenderPositionComponent : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public RenderPositionComponent(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.GameObject.transform.position = new UnityEngine.Vector3(entity.position.Value.X, entity.position.Value.Y, entity.position.Value.Z);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
    }
}
