using Entitas;

public class GameStateSystems : Feature
{
    public GameStateSystems (Contexts contexts) : base("GameState Systems") {
        Add(new ChangeDeltaTimeSystem(contexts));
        Add(new IncrementTickTimeSystem(contexts));
        Add(new DecrementTimeLeftSystem(contexts));

        Add(new ScoreSystem(contexts)); 
    }
}