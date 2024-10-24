using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody2D mybody;

    // Start is called before the first frame update
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
    }

    void Move(){
        if(Input.GetAxisRaw("Horizontal") > 0f){
            mybody.velocity= new Vector2(moveSpeed, mybody.velocity.y);
            print("Right");
        }

        if(Input.GetAxisRaw("Horizontal") < 0f){
            mybody.velocity= new Vector2(-moveSpeed, mybody.velocity.y);
            print("Left");
        }


    }

    public void PlatformMove(float x){
        mybody.velocity = new Vector2(x, mybody.velocity.y);

    }
}
