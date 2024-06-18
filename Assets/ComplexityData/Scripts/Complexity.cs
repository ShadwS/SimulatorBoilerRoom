using UnityEngine;

enum ComplexityGame {Easy, Medium, Difficult}
[CreateAssetMenu(fileName = "ComplexityData", menuName = "Complexity", order = 1)]
public class Complexity : ScriptableObject
{
    [SerializeField] private ComplexityGame _complexityGame;
    [SerializeField] private bool _displayingObjects;
}
