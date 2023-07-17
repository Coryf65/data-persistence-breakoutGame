using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager Manager;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}