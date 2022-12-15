using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{
    

    [SerializeField]
    private Transform downPose;
    [SerializeField]
    private Transform upPose;
    [SerializeField]
    private Transform elevatorswitch;
    [SerializeField]
    private GameObject elevatorSwitchLightUp;

    [SerializeField]
    private float speed;
    [SerializeField]
    private bool iselevatordown;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

  
    void Update()
    {
        ElevatorMovement();
        DisplayColor();
    }

    public void StartElevator()
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
            elevatorSwitchLightUp.SetActive(false);
        }
        else
        {
            elevatorSwitchLightUp.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerController.ElectricityActive)
        {
            StartElevator();
        }
    }
}
