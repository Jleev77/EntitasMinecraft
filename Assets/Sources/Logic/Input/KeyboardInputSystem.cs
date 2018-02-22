using Entitas;
using UnityEngine;

public class KeyboardInputSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _playerGroup;
    private GameEntity _player;

    public KeyboardInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _playerGroup = _contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        if(_player == null || !_player.isPlayer)
        {
            _player = _playerGroup.GetSingleEntity();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            var x = _player.view.GameObject.transform.forward;
            x *= 4;
            _player.ReplaceVelocity(new Vector3f(x.x, x.y, x.z));
        }
    }
}
