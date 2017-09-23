using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;


public class GameBoardSystems : Feature
{
    public GameBoardSystems (Contexts contexts ) : base ("GameBoard Systems") {
        Add(new InitializeGameBoardSystem(contexts));

        Add(new AddSealSystem(contexts));
        Add(new RemoveSealSystem(contexts));
    }
}