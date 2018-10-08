using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantsManager : MonoBehaviour {

	// Player prefs.
	const string PLAYER_TOP_SCORE = "PlayersTopScore";

    // Custom tags.
    const string OBSTACLE_TAG = "Obstacle";

    // Animation names.
    const string ANIMATION_IDLE = "Idle";
    const string ANIMATION_JUMP = "Jump";
    const string ANIMATION_FLY = "Fly";

    // Shader texture property name.
    const string SHADER_SKYDOME_OFFSET_TEXTURE_NAME = "_MainTex";

    // ************************** PUBLIC ************************** //

	// Set top score.
	public static void SetTopScore(int score) {
		// Check if realy top score.
		int savedTopScore = GetTopScore();
		if (savedTopScore < score) {
			// We checked that new score is really the best score so far, so lets save it.
			PlayerPrefs.SetInt(PLAYER_TOP_SCORE, score);
		} 
	}

	// Get top score.
	public static int GetTopScore() {
		// Get players top score.
		return PlayerPrefs.GetInt(PLAYER_TOP_SCORE);
	}

    // Get tag for specific gameobject.
    public static string GetTag(ObjectTags gameObject)
    {
        switch (gameObject)
        {
            case ObjectTags.obstacle:
                return OBSTACLE_TAG;
            default:
                return "";
        }
    }

    // Get animation name.
    public static string GetAnimationName(Animations animation)
    {
        switch (animation)
        {
            case Animations.idle:
                return ANIMATION_IDLE;
            case Animations.jump:
                return ANIMATION_JUMP;
            case Animations.fly:
                return ANIMATION_FLY;
            default:
                return "";
        }
    }

    // Get shader texture offset name.
    public static string GetShaderTextureOffSetName()
    {
        return SHADER_SKYDOME_OFFSET_TEXTURE_NAME;
    }
}