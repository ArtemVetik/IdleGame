using UnityEngine;

namespace Agava.IdleGame.Examples
{
    [RequireComponent(typeof(Rigidbody))]
    public class BodyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.2f;
        [SerializeField] private Joystick _joystic;

        private Rigidbody _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var rawDirection = new Vector3(_joystic.Direction.x, 0, _joystic.Direction.y);
            _body.velocity = rawDirection * _speed;

            transform.LookAt(transform.position + rawDirection);
        }
    }
}