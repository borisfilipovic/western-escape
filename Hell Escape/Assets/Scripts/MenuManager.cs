using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class MenuManager : MonoBehaviour {

    // Create singleton.
    public static MenuManager instance = null;

    // Private properties.

    //private GameManager gameManager;

    [SerializeField]
    private GameObject playView;

    [SerializeField]
    private GameObject replayView;

	[SerializeField]
	private Text topScore;

    // Lifecycle.

    void Awake()
    {
        // Create singleton.
        if (instance == null)
        {
            // Create singleton.
            instance = this;
        }
        else if (instance != this)
        {
            // There already is instance of this running so destroy this one.
            Destroy(gameObject);
        }

        // Dont destroy singleton when new scene is loaded. It will persist between scenes.
        DontDestroyOnLoad(gameObject);

        // Assert that gameobjects are not null.
        Assert.IsNotNull(playView);
        Assert.IsNotNull(replayView);
		Assert.IsNotNull(topScore);
    }

    void Start()
    {
        // Find game manager.
        //gameManager = GameManager.instance;

        /// Set state.
        SetGameState(GameState.playScreen);
    }

	// Update best score from player prefs.

	void updateBestScore() {
		/// Update and set top score.
		topScore.text = "Best score: " + ConstantsManager.GetTopScore().ToString ();
	}

    /******************** PUBLIC METHODS **********************/

    public void Game(GameState gameState)
    {
        SetGameState(gameState);
    }

    /******************** PRIVATE METHODS **********************/

    private void SetGameState(GameState gameStateNew)
    {
		updateBestScore();
        switch(gameStateNew)
        {
            case GameState.mainMenuScreen:
                playView.SetActive(true);
                replayView.SetActive(false);
                break;
            case GameState.playScreen:
                playView.SetActive(true);
                replayView.SetActive(false);
                break;
            case GameState.replayScreen:
                playView.SetActive(false);
                replayView.SetActive(true);
                break;
            default:
                break;
        }
    }
}
