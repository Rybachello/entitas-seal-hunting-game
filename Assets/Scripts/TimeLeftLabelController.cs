using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftLabelController : MonoBehaviour
{
    Text _label;

    void Awake ( ) {
        _label = GetComponent<Text>();
    }

    void Start ( ) {
        var context = Contexts.sharedInstance.gameState;

        context.GetGroup(GameStateMatcher.TimeLeft).OnEntityAdded +=
            (group, entity, index, component) => UpdateScore(entity.timeLeft.value);


        UpdateScore(context.timeLeft.value);
    }

    void UpdateScore (float timeLeft) {
        _label.text = "Time Left " + timeLeft.ToString("##.##") ;
    }
}