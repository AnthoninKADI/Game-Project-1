using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public List<SwitchScript> switches;
    public int requirement;
    public int currentCount = 0;
    private Animator animator;

    private void Start()
    {
        foreach(SwitchScript s in switches)
        {
            s.SetDoor(this);
        }
        animator = GetComponent<Animator>();    
    }

    public void CountSwitch()
    {
        currentCount++;
        if(currentCount >= requirement)
        {
            animator.enabled = true;
        }
    }


}
