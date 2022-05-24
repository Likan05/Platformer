using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPointsMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private float _direction;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        _direction = transform.position.x - target.position.x;
        if(_direction < 0)        
            _sprite.flipX = true;
        if (_direction > 0)
            _sprite.flipX = false;
    }
}
