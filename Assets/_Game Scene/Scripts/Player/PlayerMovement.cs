using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = gameObject.transform.forward * Input.GetAxis("Vertical") +
            gameObject.transform.right * Input.GetAxis("Horizontal");
        move = move.normalized * _speed;
        _controller.Move(move * Time.deltaTime);
    }
}