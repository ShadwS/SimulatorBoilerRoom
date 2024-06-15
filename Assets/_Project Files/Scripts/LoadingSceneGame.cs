using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneGame : MonoBehaviour
{
    [SerializeField] Image loadingImage;
    [SerializeField] Text loadingText;
    private int levl;

    private void Start()
    {
        levl = Menu.selectedLevel;
        StartCoroutine(AsyncLoad());
    }

    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync($"Level {levl}");
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImage.fillAmount = progress;
            loadingText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
