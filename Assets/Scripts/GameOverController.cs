using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private Text _gameOverText;

    private void Awake ( ) {
        _gameOverText = this.gameObject.GetComponentInChildren<Text>();
        _gameOverText.gameObject.SetActive(false);
    }

    private void Update ( ) {
        var context = Contexts.sharedInstance.gameState;
        context.GetGroup(GameStateMatcher.GameOver).OnEntityAdded +=
            (group, entity, index, component) => ShowGameOverText();
    }

    private void ShowGameOverText ( ) {
        _gameOverText.gameObject.transform
                     .DOScale(Vector3.one * 2f, 1f)
                     .OnComplete(( ) =>
                         _gameOverText.gameObject.SetActive(true));
    }
}