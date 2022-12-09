using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class tpFirst : MonoBehaviour
{

    private GameObject player;
    [SerializeField]
    private GameObject tp2;
   


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Electric"))
        {
            player.transform.position = new Vector2(tp2.transform.position.x, tp2.transform.position.y);
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        tp2.SetActive(false);
        yield return new WaitForSeconds(2f);
        tp2.SetActive(true);
    }
}

