using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique]
public class DeltaTimeComponent : IComponent
{
    public float value;
}