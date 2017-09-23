using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InitializeGameBoardSystem : IInitializeSystem, ICleanupSystem
{
    readonly GameContext _context;

    public InitializeGameBoardSystem (Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize ( ) {
        var columns = _context.globals.value.columns;
        var rows = _context.globals.value.rows;
        _context.SetGameBoard(rows, columns);

        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                CreateGameBoard(row, column);
            }
        }
    }

    private void CreateGameBoard (int row, int column) {
        var entity = _context.CreateEntity();
        entity.AddPosition(new IntVector2(row, column));
        entity.isGameBoardHole = true;
        entity.AddAsset(Res.Hole);
    }

    public void Cleanup ( ) {
        //if (!Contexts.sharedInstance.gameState.isGameOver)
        //    return;
        //foreach (var e in _context.GetEntities()) {
        //    e.isDestroyed = true;
        //}
    }
}