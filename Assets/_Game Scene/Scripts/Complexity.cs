using UnityEngine;

public enum ComplexityGame {Easy, Medium, Difficult}
[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Complexity", order = 1)]
public class Complexity : ScriptableObject
{
    [SerializeField] private ComplexityGame _complexityGame;
    [SerializeField] private bool _displayingObjects;
    [SerializeField] private float _timerGame;
}
