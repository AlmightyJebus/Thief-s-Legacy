using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodoor : MonoBehaviour
{

    public bool move = false;
    public bool move2 = false;
    public float speed = 1;
    public float closingSpeed = 1f;
    public float time = 1;
    private float time2 = 1.85f;
    public float resetTime = 1.85f;
    public int left = -1;
    public int right = 1;
    public bool timesUp = false;
    public Collider exit;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (move)
        {
            Open();
        }
        if (move2)
        {
            Close();
        }
        if (timesUp)
        {
            time = 1;
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
            {
            move = true;
        }
    }
   
    public void Open()
    {
        Reset2();
        time -= Time.deltaTime;

            if (time>0)
        {
            transform.Translate(left * speed * Time.deltaTime, 0, 0);

            
        }
            if (time<0)
        {
            move = false;
            move2 = true;
        }
            
        
    }
    public void Close()
    {
        Reset();
        time2 -= Time.deltaTime;
        if (time2 > 0)
        {
            transform.Translate(right * closingSpeed * Time.deltaTime, 0, 0);
        }
        if (time2 <0)
        {
            move2 = false;
        }
    }
    public void Reset()
    {
        time = 1;
    }
    public void Reset2()
    {
        time2 = resetTime;
    }

}
