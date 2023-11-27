
using UnityEngine;
using SpriteGlow;
public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public int damageOnCollision = 20;

    private Transform target;
    private int destPoint = 0;


    public EnemyPatrol linkedEnemy; // La référence à l'ennemi lié.
    public bool protectedWithAura = false;
    public SpriteRenderer grahpics;
    private SpriteGlowEffect spriteGlowEffect;
    void Start()
    {
        target = waypoints[destPoint];
        spriteGlowEffect = GetComponent<SpriteGlowEffect>();
        if (!protectedWithAura)
        {
            spriteGlowEffect.GlowBrightness = 0f;
            protectedWithAura = true;
        }
        else if (protectedWithAura)
        {
            spriteGlowEffect.GlowBrightness = 2.5f;
            protectedWithAura = false;
        }
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            grahpics.flipX = !grahpics.flipX;;
        }
        if(protectedWithAura == false){
            spriteGlowEffect.GlowBrightness = 0f;
        }
        else if (protectedWithAura == true)
        {
            spriteGlowEffect.GlowBrightness = 2.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageOnCollision);
        }
    }

}
