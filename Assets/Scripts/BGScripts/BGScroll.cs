using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
     public float Scroll_speed = 0.3f;
     private MeshRenderer meshRenderer;

     void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();

     }

     void Update(){
        Scroll();
     }

     void Scroll(){
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * Scroll_speed;

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);



     }

}
