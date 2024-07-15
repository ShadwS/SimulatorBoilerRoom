using TMPro;
using UnityEngine;

public class TextResult : MonoBehaviour
{
    public float TimeResult { get => _timeResult; set => _timeResult = value; }
    public int PointResult { get => _pointResult; set => _pointResult = value; }
    public TMP_Text Time { get => _time; set => _time = value; }
    public TMP_Text Point { get => _point;  set => _point = value; }
    public ComplexityGame CoplexityPanel { get => complexityPanel; }

    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _point;
    [Header("Сложность панели")]
    [SerializeField] private ComplexityGame complexityPanel;

    private float _timeResult = 120;
    private int _pointResult = 0;
}
