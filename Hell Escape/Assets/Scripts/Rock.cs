using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MoveObject {

    // Private.
    private bool gameManagerNotifiedThatScoreChanged = false;

    // Public.
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3 topPosition;

    [SerializeField]
    Vector3 bottomPosition;

	// Use this for initialization
	void Start () {
        // Start courutine.
        StartCoroutine(Move(bottomPosition));
	}

    protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            base.Update();
            if (transform.localPosition.x < -2.0f && !gameManagerNotifiedThatScoreChanged)
            {
                GameScoreChanged();
            } else if (transform.localPosition.x > 3.0f && gameManagerNotifiedThatScoreChanged)
            {
                gameManagerNotifiedThatScoreChanged = false;
            }
        }        
    }

    IEnumerator Move(Vector3 target) {
        // Move gameobject to desired position.
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f) {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Wait for some time before animating up/down.
        yield return new WaitForSeconds(0.5f);

        // Set new target position.
        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        // Call self to start courutine again.
        StartCoroutine(Move(newTarget));
    }

    private void GameScoreChanged()
    {
        gameManagerNotifiedThatScoreChanged = true;
        GameManager.instance.ScoreChanged(GameScore.add);
    }
}
