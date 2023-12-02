using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    private string tag;

    private void Awake()
    {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            tag = "Player";
        }
        else if (GameObject.FindGameObjectWithTag("PlayerFantom") != null)
        {
            tag = "PlayerFantom";
        }
            
        GameObject.FindGameObjectWithTag(tag).transform.position = transform.position;
    }
}
