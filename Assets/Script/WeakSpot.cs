
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parentTransform = transform.parent;
        
        // destroy enemy when player collides with weak spott && protectedWithAura == false
        if (collision.gameObject.tag == "Player" && parentTransform.GetComponent<EnemyPatrol>().protectedWithAura == false)
        {
            parentTransform.GetComponent<EnemyPatrol>().linkedEnemy.protectedWithAura = false;
            Destroy(objectToDestroy);
        }
    }
}
