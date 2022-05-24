using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private float _speed;

    private float _direction;
    private bool _moveRight;

    private void Start()
    {
        _direction = 1.5f;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        RaycastHit2D checkGround = Physics2D.Raycast(_ground.position, Vector2.down, _direction);

        if(checkGround.collider == null)
        {
            if (!_moveRight)
            {               
                transform.eulerAngles = new Vector3(0, -180, 0);
                _moveRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveRight = false;
            }
        }
    }
}
