using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class ZoomCamera : MonoBehaviour
{

    public bool zoomActive = false;

    public Vector3[] Target;
    public Camera Cam;
    public float speed;
    int zoom = 60;
    int normal = -60;
    int smooth = 5;

    bool isZooming = false;


    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    private void Update()
    {
        if (isZooming)
        {
            if (zoomActive)
            {

                Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 20, speed);
                if(Cam.orthographicSize >= 20)
                {
                    isZooming = false;
                }
            }
            else
            {
                Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 7, speed);
                if (Cam.orthographicSize <= 7)
                {
                    isZooming = false;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("ZoomOut"))
        {
            zoomActive = true;
            isZooming = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ZoomNormal"))
        {
            isZooming = true;
            zoomActive = false;
        }
    }

    private void Zoom(bool zoomActive)
    {
        
    }
}


