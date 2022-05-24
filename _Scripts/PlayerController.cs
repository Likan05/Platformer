using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundTransform;
    [Header ("Stats")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;

    private Vector2 _vector2;
    private float _shiftToward;
    private bool _isGround;

    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);
    private const string Jump = nameof(Jump);

    public float ShiftToward => _shiftToward;

    private void OnValidate()
    {
        if (_speed < 1f)
            _speed = 2;
        if (_jumpForce < 150)
            _jumpForce = 150;
    }

    private void Update()
    {
        Move();
        JumpUp();
    }

    private void Move()
    {
        _vector2.x = Input.GetAxis(Horizontal);
        _rigidbody2D.velocity = new Vector2(_vector2.x * _speed, _rigidbody2D.velocity.y);
        if (_vector2.x < 0)
        {
            _shiftToward = -2;
            _spriteRenderer.flipX = true;
            EnableAnimation();
        }
        else if (_vector2.x > 0)
        {
            _shiftToward = 2;
            _spriteRenderer.flipX = false;
            EnableAnimation();
        }
        else
        {
            DisableAnimation();
        }
    }

    private void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetTrigger(Jump);
        }
        CheckCharacterOnGround();
    }

    private void CheckCharacterOnGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundTransform.position, _checkRadius, _groundMask);
    }

    private void EnableAnimation()
    {
        _animator.SetFloat(Speed, 0.2f, 0.5f, Time.deltaTime);
    }

    private void DisableAnimation()
    {
        _animator.SetFloat(Speed, 0.0f);
    }
}
