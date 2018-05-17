using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    SpriteRenderer temp;
    public int offset;
    public Transform thisObject;
	
    void Awake()
    {
        temp = GetComponent<SpriteRenderer>();
    }
	void Start ()
    {
        

    }
	
	
	void Update ()
    {
        temp.sortingOrder = (int)thisObject.transform.position.x * -1 + offset;
        Debug.Log(temp.sortingOrder);
	}
}
//pistä tämä scripti jokaiseen spriteen, transform kohtaan vedä kyseinen sprite inspectorissa.
//pistä offset arvo ekaan sarjaan 1, tokassa sarjassa -1 paitsi ekaan, kolmannessa jätä arvo nollaksi
