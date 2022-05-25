using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [Header ("Position setting")]
    [SerializeField] private float _speedMove;
    
    private float _setY;
    private float _lowerLimitCamera;
    private int _zCameraShift;

    private void Awake()
    {
        _zCameraShift = 10;
        _lowerLimitCamera = -4.5f;
        _setY = 2;

        transform.position = new Vector3(_player.transform.position.x + _player.ShiftToward,
            _player.transform.position.y + _setY,
            _player.transform.position.z - _zCameraShift);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 target = new Vector3(_player.transform.position.x + _player.ShiftToward,
            _player.transform.position.y + _setY,
            _player.transform.position.z - _zCameraShift);

        if(_player.transform.position.y > _lowerLimitCamera)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target, Time.deltaTime * _speedMove);
            transform.position = newPosition;
        }        
    }
}
