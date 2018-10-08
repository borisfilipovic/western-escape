using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Score : MonoBehaviour {

    [SerializeField]
    private Text scoreLabel;

    private string scorePrefix = "Score: ";

	// Use this for initialization
	void Awake () {
        /// Assert.
        Assert.IsNotNull(scoreLabel);
	}

    /******************** PUBLIC METHODS **********************/

    public void SetScore(int newScore)
    {
        /// Display new score value.
        scoreLabel.text = scorePrefix + newScore;
    }
}
