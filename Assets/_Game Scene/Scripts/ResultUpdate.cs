using UnityEngine;

public class ResultUpdate : MonoBehaviour
{
    [SerializeField] private GameCanvas _gameCanvas;

    private void OnEnable() => _gameCanvas.OnWin += UpdateResult;

    private void OnDestroy() => _gameCanvas.OnWin -= UpdateResult;

    private void UpdateResult(float time, float point, ComplexityGame complexity)
    {
        Settings.Instance.Results.Add(new Result 
        {
            Complexity = complexity, 
            PassageTime = time,
            Point = point, 
            Level = Settings.Instance.Level, 
        });
    }
}
