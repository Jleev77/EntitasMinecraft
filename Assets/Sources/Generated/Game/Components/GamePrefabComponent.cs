//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PrefabComponent prefab { get { return (PrefabComponent)GetComponent(GameComponentsLookup.Prefab); } }
    public bool hasPrefab { get { return HasComponent(GameComponentsLookup.Prefab); } }

    public void AddPrefab(string newName) {
        var index = GameComponentsLookup.Prefab;
        var component = CreateComponent<PrefabComponent>(index);
        component.Name = newName;
        AddComponent(index, component);
    }

    public void ReplacePrefab(string newName) {
        var index = GameComponentsLookup.Prefab;
        var component = CreateComponent<PrefabComponent>(index);
        component.Name = newName;
        ReplaceComponent(index, component);
    }

    public void RemovePrefab() {
        RemoveComponent(GameComponentsLookup.Prefab);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPrefab;

    public static Entitas.IMatcher<GameEntity> Prefab {
        get {
            if (_matcherPrefab == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Prefab);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPrefab = matcher;
            }

            return _matcherPrefab;
        }
    }
}