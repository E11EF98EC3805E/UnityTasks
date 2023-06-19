using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public Slider progressBar;

    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
    }

    void Update()
    {
        Debug.Log("Loading progress: " + (loadingOperation.progress * 100) + "%");
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }
}