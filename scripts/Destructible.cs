using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class Destructible : MonoBehaviour
{
    public int score = 0;
    public GameObject scoreText;
    public Tilemap destroyTiles;
    // Start is called before the first frame update
    void Start()
    {
        destroyTiles = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyTiles == null){
            Debug.Log("you win");
        }
        Text s = scoreText.GetComponent<Text>();
        s.text = "Score: "+ score.ToString();
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 hitPos = Vector3.zero;
        foreach(ContactPoint2D hit in other.contacts){
            hitPos.x = hit.point.x - 0.01f * hit.normal.x;
            hitPos.y = hit.point.y - 0.01f * hit.normal.y;
            destroyTiles.SetTile(destroyTiles.WorldToCell(hitPos),null);
            
            score++;
            
        }
    }
}
