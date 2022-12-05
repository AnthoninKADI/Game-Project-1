using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class TPfirst : MonoBehaviour
{

    private GameObject player;
    public GameObject TP;



    private void Awake()
    {

        player = GameObject.FindWithTag("Player");


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("ching ling");
            player.transform.position = new Vector2(TP.transform.position.x, TP.transform.position.y);


            StartCoroutine(waiter());

        }
    }

    IEnumerator waiter()
    {
        TP.SetActive(false);
        yield return new WaitForSeconds(2f);
        TP.SetActive(true);
    }
}

