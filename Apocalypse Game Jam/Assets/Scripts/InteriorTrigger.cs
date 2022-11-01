using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteriorTrigger : MonoBehaviour
{
    public GameObject tilemap1;
    public GameObject tilemap2;
    public GameObject tilemap3;
    public GameObject tilemap4;
    public GameObject tilemap5;
    public GameObject tilemap6;
    public bool enterInterior;
    public bool entered;
    public TilemapCollider2D col3;

    void Start()
    {
        col3 = tilemap3.GetComponent<TilemapCollider2D>();
        col3.enabled = false;
        entered = false;
        tilemap4.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && enterInterior && !entered)
        {
            col3.enabled = true;
            tilemap2.SetActive(false);
            tilemap4.SetActive(true);
            tilemap5.SetActive(false);
            tilemap6.SetActive(false);
            entered = true;

        }

        if (collision.tag == "Player" && !enterInterior && !entered)
        {
            col3.enabled = false;
            tilemap2.SetActive(true);
            tilemap4.SetActive(false);
            tilemap5.SetActive(true);
            tilemap6.SetActive(true);
            entered = false;
        }
    }
}
