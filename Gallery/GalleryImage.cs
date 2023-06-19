using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GalleryImage : MonoBehaviour 
{
    public void ViewImage ()
    {
        int imageIndex = transform.GetSiblingIndex() + 1;
        LoadingData.imageIndex = imageIndex;
        LoadingData.rotationAllowed = true;
        LoadingData.sceneToLoad = "ImageView";
        SceneManager.LoadScene("ImageView", LoadSceneMode.Additive);
    }

}
