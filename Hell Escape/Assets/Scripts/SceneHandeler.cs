using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneHandeler : MonoBehaviour {

    // Public properties.

    public float diffX = 0.014f;
    public float skyDomeRotationDiffX = 0.01f;

    // Private properties.

    [SerializeField]
    private GameObject skyDome;

    [SerializeField]
    private Material skyDomeMaterial;

    private string shaderOffsetTextureName = "";

    // Use this for initialization
    void Awake()
    {
        // Set texture name.
        shaderOffsetTextureName = ConstantsManager.GetShaderTextureOffSetName();

        // Set assertion.
        Assert.IsNotNull(skyDome);
        Assert.IsNotNull(skyDomeMaterial);        
    }

    // Use this for initialization
    void Update()
    {
        // Animate day cicle.
        UpdateDayCycle(Time.deltaTime);
    }

    // Update day cycle.
    private void UpdateDayCycle(float deltaTime)
    {
        /// Get current x value.
        float currentX = skyDomeMaterial.GetTextureOffset(shaderOffsetTextureName).x;

        /// Calculate new x.
        float newX = currentX + deltaTime * diffX;

        /// Set new x to shader texture offset.
        skyDomeMaterial.SetTextureOffset(shaderOffsetTextureName, new Vector2(newX, 0.0f));

        /// Rotate skydome.
        skyDome.transform.Rotate(0, deltaTime + skyDomeRotationDiffX, 0);
    }
}
