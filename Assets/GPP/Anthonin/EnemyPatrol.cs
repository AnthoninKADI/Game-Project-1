using UnityEngine;
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;
    private float respawnTime;

    void Start()
    {
        respawnTime = GameManager.instance.respawnTime;
        startSpeed = speed;
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 0;
            Invoke("ResetSpeed", respawnTime);
        }
    }

    public void ResetSpeed()
    {
        speed = startSpeed;
    }
}