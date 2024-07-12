using TMPro;
using UnityEngine;

public class DisplayResult : MonoBehaviour
{
    [SerializeField] private string[] _text;
    [SerializeField] private TMP_Text[] _textsChangResult;
    //0- TimeText
    //1- PointText
    //2- ComplexityText
    private int _complexityTextIndex = 0;

    private void Start() => UpdateTextComplexity();

    public void UpdateText(float time, int points)
    {
        for(int i = 0; i < _textsChangResult.Length; i++)
        {
            switch (i)
            {
                case 0:
                    _textsChangResult[i].text = $"{time} мин";
                    break;
                case 1:
                    _textsChangResult[i].text = $"{points} / 100%";
                    break;
            }
        }
    }

    public void ButtonLeftOrRight(string Direction)
    {
       
        switch (Direction)
        {
            case "Right":
                _complexityTextIndex++;
                UpdateTextComplexity();
                break;
            case "Left":
                _complexityTextIndex--;
                UpdateTextComplexity();
                break;
        }
    }

    private void UpdateTextComplexity()
    {
        if (_complexityTextIndex >= _text.Length - 1) { _complexityTextIndex = _text.Length - 1; }
        else if (_complexityTextIndex <= 0) {  _complexityTextIndex = 0; }
        _textsChangResult[2].text = _text[_complexityTextIndex];
    }
}
