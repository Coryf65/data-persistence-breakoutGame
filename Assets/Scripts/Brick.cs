using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public int PointValue;
    public UnityEvent<int> onDestroyed;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        
        switch (PointValue)
        {
            case 1 :
                // These were not setting the color correctly for me!
                //block.SetColor("_BaseColor", Color.green);
                renderer.material.color = Color.green;
                break;
            case 2:
                //block.SetColor("_BaseColor", Color.yellow);
                renderer.material.color = Color.yellow;
                break;
            case 5:
                //block.SetColor("_BaseColor", Color.blue);
                renderer.material.color = Color.blue;
                break;
            default:
                //block.SetColor("_BaseColor", Color.red);
                renderer.material.color = Color.red;
                break;
        }
        
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}