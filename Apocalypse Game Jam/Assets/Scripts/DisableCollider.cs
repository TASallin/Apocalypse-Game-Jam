using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    public GameObject tilemap1;
    public GameObject tilemap2;
    CompositeCollider2D col;

    void Start()
    {
        col = tilemap1.GetComponent<CompositeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            col.enabled = false;
            float a = tilemap1.GetComponent<Color>().a;
            a = 130;
            float b = tilemap2.GetComponent<Color>().a;
            a = 130;
        }
    }
}
