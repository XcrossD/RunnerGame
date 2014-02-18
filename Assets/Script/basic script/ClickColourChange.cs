using UnityEngine;
using System.Collections;

public class ClickColourChange : MonoBehaviour
{
    void Start ()
    {
        Random.seed = (int)Time.time;
    }
    
    
    void OnMouseDown ()
    {
        float r = Random.Range(0f,1f);
        float g = Random.Range(0f,1f);
        float b = Random.Range(0f,1f);
        Color randomColour = new Color(r,g,b,1f);
        
        renderer.material.color = randomColour;
    }
}