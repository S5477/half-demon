using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private SpriteRenderer _render;
    [SerializeField]
    private Animator _animator;

    private Vector2 _direction;

    private string walkAnimation = "IsWalk";

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(!Pause._isPause)
        {
            Flipment();
            AnimWalk();
            _rb.MovePosition(_rb.position + _direction * Time.fixedDeltaTime * _speed);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (!Pause._isPause)
        {
            _direction = context.ReadValue<Vector2>();
        }
    }

    private void Flipment()
    {
        if (_direction.x > 0)
        {
            _render.flipX = false;
        }

        if (_direction.x < 0)
        {
            _render.flipX = true;
        }
    }

    private void AnimWalk()
    {

        if (_direction == Vector2.zero)
        {
            _animator.SetBool(walkAnimation, false);
        }
        else
        {
            _animator.SetBool(walkAnimation, true);
        }
    }
}
