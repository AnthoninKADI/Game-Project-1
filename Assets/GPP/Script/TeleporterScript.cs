using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class TeleporterScript : MonoBehaviour
{

     private GameObject player;
    [SerializeField]
    private GameObject tp1;
    [SerializeField]
    private GameObject tp2;
    [SerializeField]
    private bool secondTp;
    [SerializeField]
    private float tpCooldown;


    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite tp;
    [SerializeField]
    private Sprite tpTaken;

    private float inputTime;

    private static bool isActive = true;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inputTime = Time.time;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Electric"))
        {
            if (isActive)
            {
                if (secondTp && inputTime + tpCooldown <= Time.time)
                {
                    inputTime = Time.time;
                    isActive = false;
                    spriteRenderer.sprite = tpTaken;
                    Invoke("ChangeSprite", tpCooldown);
                    player.transform.position = new Vector2(tp1.transform.position.x, tp1.transform.position.y);
                }
                else if (!secondTp && inputTime + tpCooldown <= Time.time)
                {
                    isActive = false;
                    inputTime = Time.time;
                    spriteRenderer.sprite = tpTaken;
                    Invoke("ChangeSprite", tpCooldown);
                    player.transform.position = new Vector2(tp2.transform.position.x, tp2.transform.position.y);
                }
            }
        }
    }

    private void ChangeSprite()
    {
        isActive = true;
        spriteRenderer.sprite = tp;
    }
}