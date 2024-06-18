using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _panelTextObject;
    [SerializeField] private Text _objectText;
    private string _complexity;

    private void Awake()
    {

    }

    private void Start()
    {
        Menu.OnComplexity += UpdateComplexity;
        PlayerRayCast.OnNameObject += TextUpdateOn;
        Pause.OnPause += OnCanvas;
    }

    private void OnDestroy()
    {
        Menu.OnComplexity -= UpdateComplexity;
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
        gameObject.SetActive(value);
    }
    private void UpdateComplexity(string value)
    {
        _complexity = value;
    }
}
