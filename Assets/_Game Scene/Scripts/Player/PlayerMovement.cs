using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;

    private CharacterController _controller;

    private float _gravityForce = 0;
    private float _gravity = -9.8f;

    private void Awake() => _controller = _player.gameObject.GetComponent<CharacterController>();

    private void Update() => Move();

    private void Move()
    {
        Gravity();

        Vector3 move = _player.gameObject.transform.forward * Input.GetAxis("Vertical") +
            _player.gameObject.transform.right * Input.GetAxis("Horizontal");
        move = move.normalized * _speed;
        _controller.Move(move * Time.deltaTime);
    }

    private void Gravity()
    {
        _gravityForce = _controller.isGrounded ? -2 : _gravityForce + _gravity * Time.deltaTime;
        _controller.Move(Vector3.up * _gravityForce * Time.deltaTime);
    }
}