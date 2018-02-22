using System;
using Entitas;

public class WorldInitializeSystem : IInitializeSystem
{
    private Contexts _contexts;

    public WorldInitializeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        createPlayer();
        createWorld();
    }

    private void createWorld()
    {
        var size = 10;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    var entity = _contexts.game.CreateEntity();
                    entity.AddPosition(new Vector3f(x, y, z));
                    entity.isBlock = true;
                    entity.AddPrefab("Prefabs/Block");

                    int yy = y % 2;
                    int xx = x % 2;
                    int zz = z % 2;


                    if (((yy == xx) && zz == 0)
                        || ((yy != xx) && zz == 1))
                    {
                        entity.AddMaterial("Materials/Dirt");
                    }
                }
            }
        }
    }

    private void createPlayer()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        entity.AddPosition(new Vector3f(-10, 0, 0));
        entity.AddPrefab("Prefabs/Block");
    }
}

