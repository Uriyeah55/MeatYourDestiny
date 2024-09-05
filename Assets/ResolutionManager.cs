using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    // Reference to CanvasScaler component
    public CanvasScaler canvasScaler;

    void Start()
    {
        AdjustResolutionAndScaling();
    }

    private void AdjustResolutionAndScaling()
    {
        // Check if we are running in WebGL
#if UNITY_WEBGL
        // Set a smaller resolution for WebGL build to improve performance
        Screen.SetResolution(960, 540, false); // Example: 960x540 resolution, windowed mode
        if (canvasScaler != null)
        {
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(960, 540); // Adjust for WebGL resolution
        }
#else
        // Set resolution for PC build (1920x1080)
        Screen.SetResolution(1920, 1080, true); // Fullscreen mode
        if (canvasScaler != null)
        {
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080); // Adjust for PC resolution
        }
#endif
    }
}
