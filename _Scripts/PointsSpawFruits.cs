using UnityEngine;

public class PointsSpawFruits : MonoBehaviour
{
    [SerializeField] private Transform _spawnFruits;
    [SerializeField] private GameObject[] _prefabFruits;

    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_spawnFruits.childCount];
        
        for (int i = 0; i < _spawnFruits.childCount; i++)
        {
            _points[i] = _spawnFruits.GetChild(i);
        }
        ArrangeRandom();
    }

    private void ArrangeRandom()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            int index = Random.Range(0, 5);
            Instantiate(_prefabFruits[index], new Vector3(_points[i].position.x, _points[i].position.y, 0), Quaternion.identity);
        }
    }
}
