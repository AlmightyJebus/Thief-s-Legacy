using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    SpriteRenderer tempRend;
    float timer = 3;
    public bool isPlayer;

    void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            tempRend.color = new Color(1, 1, 1, 0.5f);
            timer = 3;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(isPlayer == false && other.GetComponent<Depth>().isPlayer == true)
        {
            tempRend.color = new Color(1, 1, 1, 0.5f);
            timer = 3;
        }
    }
}
