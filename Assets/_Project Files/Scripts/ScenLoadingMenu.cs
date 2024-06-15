using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenLoadingMenu : MonoBehaviour
{
    [SerializeField] string nameScene;
    [SerializeField] Image loadingImage;
    [SerializeField] Text loadingText;
    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }
    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImage.fillAmount = progress;
            loadingText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
