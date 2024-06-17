using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _panelTextObject;
    [SerializeField] private Text _ObjectText;
    [SerializeField] private Image _aim;

    private void Start()
    {
        PlayerRayCast.OnNameObject += TextUpdateOn;
        PlayerRayCast.OfNameObject += TextUpdateOf;
        Pause.OnPause += OnCanvas;
    }

    private void OnDestroy()
    {
        PlayerRayCast.OnNameObject -= TextUpdateOn;
        PlayerRayCast.OfNameObject -= TextUpdateOf;
        Pause.OnPause -= OnCanvas;
    }

    private void TextUpdateOn(string text)
    {
        _panelTextObject.SetActive(true);
        _ObjectText.text = text;
    }
    private void TextUpdateOf()
    {
        _panelTextObject.SetActive(false);
    }
    private void OnCanvas(bool value)
    {
        gameObject.SetActive(value);
    }
}
