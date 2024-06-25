using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void LateUpdate() => Animation();

    private void Animation()
    {
        _animator.SetFloat("y", Input.GetAxis("Vertical"));
        _animator.SetFloat("x", Input.GetAxis("Horizontal"));
    }
}