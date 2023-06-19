using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrientationScript : MonoBehaviour {

void Update() {
  if (Application.isMobilePlatform == true && LoadingData.rotationAllowed) {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
          Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
  else Screen.orientation = ScreenOrientation.Portrait;
  }
}