using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMonitor : MonoBehaviour
{
    public Collider playerAbove, playerBelow;
    public static Transform player;
    SpriteRenderer tempRend;
    
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        tempRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.position) < 20.0f)
        {
            decideColliderToUse();
            decideSortingOrder();
        }
    }

    void decideSortingOrder()
    {
        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;
    }

    void decideColliderToUse()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            playerAbove.enabled = true;
            playerBelow.enabled = false;
        }

        else
        {
            playerAbove.enabled = false;
            playerBelow.enabled = true;
        }
    }
}
