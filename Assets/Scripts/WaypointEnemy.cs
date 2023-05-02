using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEnemy : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoint;
    Vector3 targetPos;
    [SerializeField]
    [Range(0, 1)]
    float moveSpeed = 0;
    int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = waypoint[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.5f * moveSpeed);

        if (Vector3.Distance(transform.position, targetPos) < 0.3f)
        {
            if(waypointIndex >= waypoint.Length - 1)
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex++;
            }
            targetPos = waypoint[waypointIndex].position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10.0f);
        }
    }

}
