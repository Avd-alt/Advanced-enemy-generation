using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private float _raycastDistance = 1f;

    private void Update()
    {
        MoveToTarget();
        RotateTowardsTarget();
        CheckObstacle();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;

        Vector3 directionToTarget = (_target.position - transform.position).normalized;

        transform.Translate(_speed * Time.deltaTime * directionToTarget);
    }

    private void RotateTowardsTarget()
    {
        if (_target == null)
            return;

        transform.LookAt(_target);
    }

    private void CheckObstacle()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _raycastDistance))
        {
            if (hit.collider.GetComponent<WaypointMovement>())
            {
                Destroy(gameObject);
            }
        }
    }
}