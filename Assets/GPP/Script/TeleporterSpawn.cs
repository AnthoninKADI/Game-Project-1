using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class TeleporterSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject tp1;
    [SerializeField]
    private GameObject tp2;
    private Collider2D tpCollider;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        tpCollider= tp1.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(tp2.transform.position.x, tp2.transform.position.y);
        }
    }
}