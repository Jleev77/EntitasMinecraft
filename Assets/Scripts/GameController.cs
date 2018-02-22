using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    private Systems _systems;
    public Transform _transform;

	// Use this for initialization
	void Start () {
        var contexts = Contexts.sharedInstance;
        _systems = new Systems();
        _systems.Add(createGameSystems(contexts));
        _systems.Add(createInputSystems(contexts));
        _systems.Initialize();
	}

    private Systems createGameSystems(Contexts contexts)
    {
        return new Feature("Game")
                .Add(new WorldInitializeSystem(contexts))
                .Add(new AddViewFromPrefabSystem(contexts, _transform))
                .Add(new RenderPositionComponent(contexts))
                .Add(new RenderDirectionSystem(contexts))
                .Add(new RenderMaterialComponent(contexts))
                .Add(new VelocityMoveSystem(contexts))
                ;
    }
    private Systems createInputSystems(Contexts contexts)
    {
        return new Feature("Input")
                .Add(new ClickInputSystem())
                .Add(new KeyboardInputSystem(contexts))
                ;
    }


    // Update is called once per frame
    void Update () {
        _systems.Execute();
	}
}