using UnityEngine;

public class ResultControl : MonoBehaviour
{
    [SerializeField] private DisplayResult[] _displayResults;
    private Settings _settings;
    private int _indexResult;

    private void Start()
    {
        _settings = Settings.Instance;
        _indexResult = 0;
        UpdateResultDisplayng();
    }

    private void UpdateResultDisplayng()
    {
        if (_settings.Results.Count != 0) 
        {
            for (int i = 0; i < _settings.Results.Count; i++)
            {
                if (_settings.Results[i].Level == _displayResults[_indexResult].LevelResult)
                {
                    CheckingComplexity(i);
                }
                else
                {
                    _indexResult++;
                }
            }
        } 
    }

    private void CheckingComplexity(int i)
    {
        switch (_settings.Results[i].Complexity)
        {
            case ComplexityGame.Easy:
                {
                    CheckingValuesResult(i);
                    break;
                }
            case ComplexityGame.Medium:
                {
                    CheckingValuesResult(i);
                    break;
                }
            case ComplexityGame.Difficult:
                {
                    CheckingValuesResult(i);
                    break;
                }
        }
    }

    private void CheckingValuesResult(int i)
    {
        if (_settings.Results[i].PassageTime < _displayResults[_indexResult].PanelComplexity[(int)_settings.Results[i].Complexity].TimeResult
            || _settings.Results[i].Point > _displayResults[_indexResult].PanelComplexity[(int)_settings.Results[i].Complexity].PointResult)
        {
            _displayResults[_indexResult].UpdateText(_settings.Results[i].PassageTime, _settings.Results[i].Point, _settings.Results[i].Complexity);
        }
        else
        {
            _settings.Results.Remove(_settings.Results[i]);
        }
    }
}
