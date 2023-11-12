
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy enemy when player collides with weak spot
        if (collision.gameObject.tag == "Player")
        {
            Destroy(objectToDestroy);
        }
    }
}
