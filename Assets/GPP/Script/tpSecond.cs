using System.Collections;
using UnityEngine;


public class tpSecond : MonoBehaviour
{

    private GameObject player;
    public GameObject tp1;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Electric") )
        {
            player.transform.position = new Vector2(tp1.transform.position.x, tp1.transform.position.y);
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        tp1.SetActive(false);
        yield return new WaitForSeconds(2f);
        tp1.SetActive(true);
    }

    
}