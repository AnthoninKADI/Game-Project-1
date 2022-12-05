using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 Velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + posOffset, ref Velocity, timeOffset);
    }
}
