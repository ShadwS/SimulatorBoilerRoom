using UnityEngine;

public class ResultUpdate : MonoBehaviour
{
    [SerializeField] private GameCanvas _gameCanvas;

    private void OnEnable() => _gameCanvas.OnWin += UpdateResult;

    private void OnDestroy() => _gameCanvas.OnWin -= UpdateResult;

    private void UpdateResult(float time, int point, ComplexityGame complexity, string alarmName)
    {
        Settings.Instance.Results.Add(new Result 
        {
            AlarmName = alarmName, 
            Complexity = complexity, 
            PassageTime = time,
            Point = point, 
            Level = Settings.Instance.Level, 
            Paseed = true 
        });
    }
}
