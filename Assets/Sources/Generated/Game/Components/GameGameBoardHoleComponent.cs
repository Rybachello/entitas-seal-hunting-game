//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameBoardHoleComponent gameBoardHoleComponent = new GameBoardHoleComponent();

    public bool isGameBoardHole {
        get { return HasComponent(GameComponentsLookup.GameBoardHole); }
        set {
            if (value != isGameBoardHole) {
                if (value) {
                    AddComponent(GameComponentsLookup.GameBoardHole, gameBoardHoleComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.GameBoardHole);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameBoardHole;

    public static Entitas.IMatcher<GameEntity> GameBoardHole {
        get {
            if (_matcherGameBoardHole == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameBoardHole);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameBoardHole = matcher;
            }

            return _matcherGameBoardHole;
        }
    }
}