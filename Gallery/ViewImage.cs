using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ViewImage : MonoBehaviour
{
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        Coroutine request = StartCoroutine(DownloadImage(LoadingData.imageIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                BackButton();
 
                return;
            }
        }
    }
    
    public void BackButton()
    {
        LoadingData.rotationAllowed = false;
        SceneManager.UnloadSceneAsync("ImageView");
    }

    IEnumerator DownloadImage(int imageIndex)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(LoadingData.urlImages + imageIndex.ToString() + ".jpg");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error.ToString() + " " + imageIndex.ToString());
        else 
        {
            img.transform.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        yield return new WaitForSeconds(0.01f);
    }
}
