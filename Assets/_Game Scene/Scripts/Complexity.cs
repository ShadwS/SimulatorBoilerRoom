using UnityEngine;

public enum ComplexityGame {Easy, Medium, Difficult}
[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Complexity", order = 1)]
public class Complexity : ScriptableObject
{
    public float Time { get { return _time; } }

    public bool DisplayingObject { get { return _displayingObjects; } }

    public ComplexityGame ComplexityGame { get { return _complexityGame; } }

    [SerializeField] private ComplexityGame _complexityGame;
    [SerializeField] private bool _displayingObjects;
    [SerializeField] private float _time;
}
