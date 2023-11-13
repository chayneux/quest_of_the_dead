
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 0;
    // Start is called before the first frame update
    public SpriteRenderer grahpics;
    void Start()
    {
        target = waypoints[destPoint];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            grahpics.flipX = !grahpics.flipX;
        }
    }
}
