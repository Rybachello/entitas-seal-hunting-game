//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity gameOverEntity { get { return GetGroup(GameStateMatcher.GameOver).GetSingleEntity(); } }

    public bool isGameOver {
        get { return gameOverEntity != null; }
        set {
            var entity = gameOverEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGameOver = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    static readonly GameOverComponent gameOverComponent = new GameOverComponent();

    public bool isGameOver {
        get { return HasComponent(GameStateComponentsLookup.GameOver); }
        set {
            if (value != isGameOver) {
                if (value) {
                    AddComponent(GameStateComponentsLookup.GameOver, gameOverComponent);
                } else {
                    RemoveComponent(GameStateComponentsLookup.GameOver);
                }
            }
        }
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
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherGameOver;

    public static Entitas.IMatcher<GameStateEntity> GameOver {
        get {
            if (_matcherGameOver == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.GameOver);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherGameOver = matcher;
            }

            return _matcherGameOver;
        }
    }
}