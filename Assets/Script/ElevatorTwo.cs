using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorTwo : MonoBehaviour
{
    public Transform player;
    public Transform elevatorswitch;
    public Transform downPose;
    public Transform upPose;
    public SpriteRenderer elevator;

    public float speed;
    public bool iselevatordown;

    public bool playerInside;
  
    void Start()
    {
        playerInside = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

  
    void Update()
    {
        ElevatorMovement();
        DisplayColor();
    }

    public void StartElevator()
    {
        if (playerInside)
        {
            if (transform.position.y == downPose.position.y)
            {
                iselevatordown = true;
            }
            else if (transform.position.y == upPose.position.y)
            {
                iselevatordown = false;
            }
        }
    }

    private void ElevatorMovement()
    {
        if (iselevatordown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upPose.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPose.position, speed * Time.deltaTime);
        }
    }

    private void DisplayColor()
    {
        if(transform.position.y <= downPose.position.y || transform.position.y >= upPose.position.y)

        {
            elevator.color = Color.green;
        }
        else
        {
            elevator.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
}
