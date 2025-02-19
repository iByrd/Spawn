using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] waypoints;

    int nextWaypoint = 1;
    float distanceToWaypoint;

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        distanceToWaypoint = Vector2.Distance(transform.position, waypoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position,
            moveSpeed * Time.deltaTime);
        
        if (distanceToWaypoint < 0.2f)
        {
            ChooseNextWaypoint();
        }
    }

    void ChooseNextWaypoint()
    {
        nextWaypoint++;

        if (nextWaypoint == waypoints.Length)
        {
            nextWaypoint = 0;
        }
    }
}
