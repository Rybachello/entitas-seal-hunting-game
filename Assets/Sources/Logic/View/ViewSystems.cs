using Entitas;

public class ViewSystems : Feature
{
    public ViewSystems (Contexts contexts) : base("View System") {
        Add(new SetViewSystem(contexts));
        Add(new AddViewComponentSystem(contexts));
        Add(new RemoveViewComponentSystem(contexts));
    }
}