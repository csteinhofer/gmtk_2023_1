using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator my_anime;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        
        
    }
    private void FixedUpdate()
    {
        //movement & animation
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        my_anime.SetFloat("Horizontal", movement.x);
        my_anime.SetFloat("Vertical", movement.y);

        my_anime.SetFloat("Speed", movement.sqrMagnitude);

        //set last direction for proper transition to idle anim
        if (movement.sqrMagnitude > 0) {
            my_anime.SetFloat("LastDirHor", movement.x);
            my_anime.SetFloat("LastDirVer", movement.y);
        }
        
    }
}
