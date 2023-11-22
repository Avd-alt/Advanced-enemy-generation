using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _pathTarget;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_pathTarget.childCount];

        for (int i = 0; i < _pathTarget.childCount; i++)
        {
            _points[i] = _pathTarget.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        RotateTowardsTarget(target);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if( _currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void RotateTowardsTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _speed);
        }
    }
}