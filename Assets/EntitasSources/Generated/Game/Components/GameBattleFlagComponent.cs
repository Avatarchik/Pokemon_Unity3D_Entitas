//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity battleFlagEntity { get { return GetGroup(GameMatcher.BattleFlag).GetSingleEntity(); } }

    public bool isBattleFlag {
        get { return battleFlagEntity != null; }
        set {
            var entity = battleFlagEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isBattleFlag = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BattleFlagComponent battleFlagComponent = new BattleFlagComponent();

    public bool isBattleFlag {
        get { return HasComponent(GameComponentsLookup.BattleFlag); }
        set {
            if (value != isBattleFlag) {
                var index = GameComponentsLookup.BattleFlag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : battleFlagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBattleFlag;

    public static Entitas.IMatcher<GameEntity> BattleFlag {
        get {
            if (_matcherBattleFlag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BattleFlag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBattleFlag = matcher;
            }

            return _matcherBattleFlag;
        }
    }
}
