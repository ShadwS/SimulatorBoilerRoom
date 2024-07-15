using UnityEngine;

public class Result : MonoBehaviour
{
    public int Level { get => _level; set => _level = value; }
    public ComplexityGame Complexity { get => _complexity; set => _complexity = value; }
    public float PassageTime { get => _passageTime; set => _passageTime = value; }
    public int Point { get => _point; set => _point = value; }

    private int _level = 0;
    private ComplexityGame _complexity;
    private float _passageTime = 0;
    private int _point = 0;
}
