using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique]
public class TimeLeftComponent : IComponent
{
    public float value;
}