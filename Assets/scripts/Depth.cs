using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    SpriteRenderer tempRend;
    float timer = 3;

    void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;
    }
}
