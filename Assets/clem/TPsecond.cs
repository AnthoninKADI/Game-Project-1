using System.Collections;
using UnityEngine;


public class TPsecond : MonoBehaviour
{

    private GameObject player;
    public GameObject TP1;



    private void Awake()
    {

        player = GameObject.FindWithTag("Player");


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            Debug.Log("bing");
            player.transform.position = new Vector2(TP1.transform.position.x, TP1.transform.position.y);


            StartCoroutine(waiter());

        }
    }

    IEnumerator waiter()
    {
        TP1.SetActive(false);
        yield return new WaitForSeconds(2f);
        TP1.SetActive(true);
    }
}