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
        tpCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.BlackScreenObject.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            Invoke("BlackScreen",1.65f);
        }
    }

    private void BlackScreen()
    {
        //player.GetComponent<Rigidbody2D>().gravityScale = 8;
        GameManager.instance.BlackScreenObject.SetActive(false);
        Invoke("ChangePosition", 0f);
    }

    private void ChangePosition()
    {
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.transform.position = new Vector2(tp2.transform.position.x, tp2.transform.position.y);
    }
}