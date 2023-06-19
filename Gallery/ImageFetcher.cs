using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageFetcher : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject content;
    public GameObject imagePrefab;
    int imageIndex = 0;
    bool isScrolling = false;

    void Start() 
    {
        isScrolling = false;
        if (scrollRect.verticalNormalizedPosition == 0f)
        {
            Debug.Log(scrollRect.verticalNormalizedPosition);
            FetchImages();
        }
    }

    // Проверяет, достаточно ли далеко доскроллили, чтобы догрузить изображения
    public void CheckScrollPosition()
    {
        if(scrollRect.verticalNormalizedPosition <= 0.01f && isScrolling == false)
         {
            FetchImages();
         }

    }


    public void FetchImages()
    {
        imageIndex++;
        Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();
        
        Coroutine request = StartCoroutine(DownloadImage(imageIndex));

    }

    // Проверяет, есть ли изображение. Если есть, то спавним новую превью
    IEnumerator DownloadImage(int imageIndex)
    {
        isScrolling = true;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(LoadingData.urlImages + imageIndex.ToString() + ".jpg");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error.ToString() + " " + imageIndex.ToString());
        else 
        {       
            GameObject previewImage = Instantiate(imagePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            previewImage.transform.SetParent(content.gameObject.transform);
            previewImage.transform.Find("RawImage").GetComponent<RawImage>().texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        yield return new WaitForSeconds(0.01f);
        isScrolling = false;
    }


}
