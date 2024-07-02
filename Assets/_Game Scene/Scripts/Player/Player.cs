using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private Transform _camera;

    private void Awake() => Instance = this;

    private void Start()
    {
        if (Settings.Instance.Complexity != ComplexityGame.Difficult)
        {
            _camera.gameObject.AddComponent<DisplayObject>();
        }
    }
}