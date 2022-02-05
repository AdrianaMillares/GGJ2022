using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraFollow cam;
    public Animator anim;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //anim.ResetTrigger("FadeIn");
        if (collision.gameObject.tag == "Player")
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            collision.transform.position += playerChange;

            anim.SetTrigger("FadeOut");
            Invoke(nameof(FadeOut), 0f);
        } 
    }

    void FadeOut()
    {
        anim.SetTrigger("FadeIn");
    }
}