using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    // Start is called before the first frame update

    public float min_X = -2.6f, max_X = 2.6f, min_Y = -5.6f;
    private bool Out_of_bounds;

    void Update(){
        CheckBounds();
    }

    void CheckBounds(){
        Vector2 temp = transform.position;

        if(temp.x > max_X){
            temp.x = max_X;
        }

        if(temp.x < min_X){
            temp.x = min_Y;
        }

        transform.position = temp;

        if(temp.y <= min_Y){
            if(!Out_of_bounds){
                Out_of_bounds = true;

                // sound manager death sound;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
                // gamemanager restart game;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Top Spikes"){
            transform.position = new Vector2(1000f, 1000f);
                 SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
        }
    }
}
