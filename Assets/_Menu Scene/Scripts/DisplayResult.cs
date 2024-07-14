using TMPro;
using UnityEngine;

public class DisplayResult : MonoBehaviour
{
    public float Time { get => _time; }
    public int point { get => _point; }
    public int LevelResult {  get => _levelResult; }

    [SerializeField] private ResultControl _control;
    [SerializeField] private int _levelResult;
    [SerializeField] private string[] _text;
    [SerializeField] private TMP_Text[] _textsChangResult;
    //0- TimeText
    //1- PointText
    //2- ComplexityText
    private int _complexityTextIndex = 0;
    private float _time = 120;
    private int _point = 0;

    private void Start() => UpdateTextComplexity();

    public void UpdateText(float time, int points)
    {
        _time = time;
        _point = points;
        if (_time == 0) { _textsChangResult[0].text = "-"; }
        else{ _textsChangResult[0].text = string.Format("{0:0}" + ".сек", _time); }
        if(_point == 0) { _textsChangResult[1].text = "-"; }
        else { _textsChangResult[1].text = $"{_point} / 100%"; }     
    }

    public void ButtonLeftOrRight(string Direction)
    {
       
        switch (Direction)
        {
            case "Right":
                _complexityTextIndex++;
                _control.UpdateResultComplexity((ComplexityGame)_complexityTextIndex, _levelResult);
                UpdateTextComplexity();
                break;
            case "Left":
                _complexityTextIndex--;
                _control.UpdateResultComplexity((ComplexityGame)_complexityTextIndex, _levelResult);
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
