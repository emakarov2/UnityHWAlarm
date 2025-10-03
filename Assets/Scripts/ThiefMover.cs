using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;

    private float _almostReachPositionDistance = 0.1f;


    private int _currentWaypointIndex = 0;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) <= _almostReachPositionDistance) 
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards
            (
            transform.position,
            _waypoints[_currentWaypointIndex].position,
            _speed * Time.deltaTime
            );
    }
}