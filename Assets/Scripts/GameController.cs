using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public Globals Globals;

        Systems _systems;

        void Awake ( ) {
           
          
            
            // Suggested systems lifecycle:
            // systems.Initialize() on Start
            // systems.Execute() on Update
            // systems.Cleanup() on Update after systems.Execute()
            // systems.TearDown() on OnDestroy
            var contexts = Contexts.sharedInstance;
            Contexts.sharedInstance.game.ReplaceGlobals(Globals);

            _systems = createSystems(contexts);
            _systems.Initialize();
        }
        
        void Update ( ) {
            _systems.Execute();
            _systems.Cleanup();
        }

        void OnDestroy ( ) {
            _systems.TearDown();
        }

        Systems createSystems (Contexts contexts) {
            return new Feature("Systems")

                    // Input 
                    .Add(new InputSystems(contexts))
                    // Update
                    .Add(new GameBoardSystems(contexts))
                    .Add(new GameStateSystems(contexts))
                    // Render
                    .Add(new ViewSystems(contexts))

                    // Destroy
                    .Add(new DestroySystem(contexts))
                ;
        }
    }
}