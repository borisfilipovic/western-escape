using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animations.
public enum Animations
{
    idle,
    jump,
    fly,
};

// Tags for game objects.
public enum ObjectTags
{
    obstacle,
};

// Game states.
public enum GameState
{
    mainMenuScreen,
    playScreen,
    replayScreen,
};

// Game score.
public enum GameScore
{
    add,
    remove,
    reset,
};