using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    // Public properties.
    [SerializeField]
    float objectSpeed = 1f;

    [SerializeField]
    float startPosition = 66.0f;

    // Private properties.
    [SerializeField]
    private float resetPosition = -42.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        // Check if game over.
        if (GameManager.instance.GameOver)
        {
            // It's game over so lets exit this update.
            return;
        }

        // Move object to the left.
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        if (transform.localPosition.x <= resetPosition) {
            Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }

    /******************** PUBLIC METHODS **********************/

    public void setStart(Vector3 position)
    {
        /// Set start position.
        gameObject.transform.position = position;
    }
}
