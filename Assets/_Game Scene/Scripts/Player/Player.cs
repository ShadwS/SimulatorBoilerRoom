using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Start()
    {
        if (Settings.Instance.Complexity != ComplexityGame.Difficult)
        {
            _camera.gameObject.AddComponent<PlayerRayCast>();
        }
    }
}