using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PositionComponent : IComponent
{
    [EntityIndex]
    public IntVector2 value;
}