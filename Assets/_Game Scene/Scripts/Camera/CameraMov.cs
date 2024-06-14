using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField] private Transform eyePosition;
    private void LateUpdate()
    {
        transform.position = eyePosition.position;
    }
}
