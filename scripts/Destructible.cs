using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructible : MonoBehaviour
{
    public Tilemap destroyTiles;
    // Start is called before the first frame update
    void Start()
    {
        destroyTiles = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 hitPos = Vector3.zero;
        foreach(ContactPoint2D hit in other.contacts){
            hitPos.x = hit.point.x - 0.01f * hit.normal.x;
            hitPos.y = hit.point.y - 0.01f * hit.normal.y;
            destroyTiles.SetTile(destroyTiles.WorldToCell(hitPos),null);
        }
    }
}
