using TMPro;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _panelTextObject;
    [SerializeField] private GameObject _panelPlayerInterface;
    [SerializeField] private GameObject _player;
    [SerializeField] private Complexity[] _scriptableObject; 
    [SerializeField] private TextMeshProUGUI _objectText;
    private Complexity _selectedDifficulty;

    private void Awake()
    {
        for(int i = 0; i < _scriptableObject.Length; i++)
        {
            if (Settings.Instance.Complexity == _scriptableObject[i].name)
            {
                _selectedDifficulty = _scriptableObject[i];
            }
        }
    }

    private void Start()
    {
        _panelTextObject.SetActive(false);
        if (_selectedDifficulty.name != "Difficult")
        {
            _player.AddComponent<PlayerRayCast>();
        }
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
