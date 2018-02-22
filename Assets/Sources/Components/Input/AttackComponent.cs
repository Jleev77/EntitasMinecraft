using Entitas;

[Input]
public class AttackComponent : IComponent
{
    public Entity Source;
    public Vector3f Direction;
}