using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    public float min_X = -1f, max_X = 1f, min_Y = -5.6f;
    private bool Out_of_bounds;

    void Update(){
        CheckBounds();
    }

    void CheckBounds(){
        Vector2 temp = transform.position;

        // Limit X position to be within the min and max bounds
        if(temp.x > max_X){
            temp.x = max_X;
        }
        if(temp.x < min_X){
            temp.x = min_X;
        }

        // Apply the modified position back to the transform
        transform.position = temp;

        // Check Y position for out-of-bounds and trigger game over
        if(temp.y <= min_Y){
            if(!Out_of_bounds){
                Out_of_bounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.ShowGameOver();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Top Spikes"){
            // Move player far offscreen as a "death" effect
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.ShowGameOver();
        }
    }
}