using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorTwo : MonoBehaviour
{

    public Transform player;
    public Transform elevatorswitch;
    public Transform downPose;
    public Transform upPose;
    public SpriteRenderer elevator;

    public float speed;
    public bool iselevatordown;
  
    void Start()
    {
        
    }

  
    void Update()
    {
        StartElevator();
        DisplayColor();
    }

    public void StartElevator()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(transform.position.y == downPose.position.y)
            {
                iselevatordown = true;
            }
            else if(transform.position.y == upPose.position.y)
            {
                iselevatordown = false;
            }
        }
        if (iselevatordown)
        {
            transform.position = Vector2.MoveTowards(transform.position,upPose.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPose.position, speed * Time.deltaTime);
        }
    }

    public void DisplayColor()
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
}
