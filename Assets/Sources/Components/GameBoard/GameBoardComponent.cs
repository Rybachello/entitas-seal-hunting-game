using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class GameBoardComponent : IComponent
{
    public int columns;
    public int rows;
}