using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorDocument : MonoBehaviour
{
    public List<DocumentScript> switches;
    public int requirement;
    public int currentCount = 0;
    private Animator animator;

    private void Start()
    {
        foreach (DocumentScript s in switches)
        {
            s.SetDoorDocument(this);
        }
        animator = GetComponent<Animator>();
    }

    public void CountSwitch()
    {
        currentCount++;
        if (currentCount >= requirement)
        {
            animator.enabled = true;
        }
    }
}
