using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [Header ("Position setting")]
    [SerializeField] private float _speedMove;
    [SerializeField] private float setY;

    private void Awake()
    {
        transform.position = new Vector3(_player.transform.position.x + _player.ShiftToward,
            _player.transform.position.y + setY,
            _player.transform.position.z - 10);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 target = new Vector3(_player.transform.position.x + _player.ShiftToward,
            _player.transform.position.y + setY,
            _player.transform.position.z - 10);

        if(_player.transform.position.y > -5)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target, Time.deltaTime * _speedMove);
            transform.position = newPosition;
        }        
    }
}
