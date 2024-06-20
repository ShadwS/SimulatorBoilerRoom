using TMPro;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _panelTextObject;
    [SerializeField] private GameObject _panelPlayerInterface;
    [SerializeField] private TextMeshProUGUI _objectText;

    private void Start()
    {
        _panelTextObject.SetActive(false);
        PlayerRayCast.OnNameObject += TextUpdateOn;
        Pause.OnPause += OnCanvas;
    }

    private void OnDestroy()
    {
        PlayerRayCast.OnNameObject -= TextUpdateOn;
        Pause.OnPause -= OnCanvas;
    }

    private void TextUpdateOn(string text,bool value)
    {
        _objectText.text = text;
        if (!value)
        {
            _panelTextObject.SetActive(false);
        }
        else
        { 
            _panelTextObject.SetActive(true);
        }
    }
    private void OnCanvas(bool value)
    {
        _panelPlayerInterface.SetActive(value);
    }
}
