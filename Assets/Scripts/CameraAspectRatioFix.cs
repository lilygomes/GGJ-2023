using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// copied from https://gamedev.stackexchange.com/a/144578

[RequireComponent(typeof(Camera))]
public class CameraAspectRatioFix : MonoBehaviour
{
    // Aspect ratio defined here
    public Vector2 targetAspect = new Vector2(4, 3);

    private Camera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        UpdateCrop();
    }

    // Update is called once per frame
    void UpdateCrop()
    {
        // Determine ratios of screen/window & target, respectively.
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = targetAspect.x / targetAspect.y;

        if(Mathf.Approximately(screenRatio, targetRatio)) {
            // Screen or window is the target aspect ratio: use the whole area.
            _camera.rect = new Rect(0, 0, 1, 1);
        } else if(screenRatio > targetRatio) {
            // Screen or window is wider than the target: pillarbox.
            float normalizedWidth = targetRatio / screenRatio;
            float barThickness = (1f - normalizedWidth)/2f;
            _camera.rect = new Rect(barThickness, 0, normalizedWidth, 1);
        } else {
            // Screen or window is narrower than the target: letterbox.
            float normalizedHeight = screenRatio / targetRatio;
            float barThickness = (1f - normalizedHeight) / 2f;
            _camera.rect = new Rect(0, barThickness, 1, normalizedHeight);
        }
    }
}
