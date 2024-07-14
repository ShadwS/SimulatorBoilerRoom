using UnityEngine;

public class ResultControl : MonoBehaviour
{
    [SerializeField] private DisplayResult[] _displayResults;
    private Settings _settings;

    private void Start()
    {
        _settings = Settings.Instance;
        UpdateFulResultDisplayng();
    }

    private void UpdateFulResultDisplayng()
    {
        if (_settings.Results.Count == 0)
        {
            for (int i = 0; i < _displayResults.Length; i++)
            {
                _displayResults[i].UpdateText(0, 0);
            }
        }
        else
        {
            //_settings.Results.OrderBy(Result => Result.Level);
            int index = 0;
            for (int i = 0; i < _settings.Results.Count; i++)
            {
                if (_settings.Results[i].Level == _displayResults[index].LevelResult)
                {
                    if (_settings.Results[i].PassageTime < _displayResults[index].Time || _settings.Results[i].Point > _displayResults[index].point)
                    {
                        if (_settings.Results[i].Complexity == (int)ComplexityGame.Easy)
                        {
                            _displayResults[index].UpdateText(0, _settings.Results[i].Point);
                        }
                        _displayResults[index].UpdateText(_settings.Results[i].PassageTime, _settings.Results[i].Point);
                    }
                    else
                    {
                        _settings.Results.Remove(_settings.Results[i]);
                    }
                }
                else
                {
                    index++;
                }
            }
        }
    }

    public void UpdateResultComplexity(ComplexityGame complexity, int level)
    {
        if (_settings.Results.Count == 0) {  return; }
        for (int i = 0; i < _settings.Results.Count; i++) 
        {
            print(i);
            if (_settings.Results[i].Level == level && _settings.Results[i].Complexity == complexity)
            {
                _displayResults[level - 1].UpdateText(_settings.Results[i].PassageTime, _settings.Results[i].Point); 
            }
            else
            {
                _displayResults[level - 1].UpdateText(0, 0);
            }
        }
    }
}
