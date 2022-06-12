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
    public BoundsInt area;
    public TileBase[] restoreTiles;
    public List<Tile> restorTiles = new List<Tile>();
    public List<Vector3> locationOf = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        destroyTiles = GetComponent<Tilemap>();
        area = destroyTiles.cellBounds;
        restoreTiles = destroyTiles.GetTilesBlock(area);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.isAtZero())
        {
            resto();
            score = 0;
            Ball.reset();
        }
        TileBase[] tileArray = destroyTiles.GetTilesBlock(area);
        // bool isEmpty =  tileArray.All(x => !x.HasValue);
        // if (isEmpty<TileBase>(tileArray))
        // {
        //     Debug.Log("you win");
        // }
        if (isEmpty())
        {
            Debug.Log("you win");
        }
        // if (tileArray.Length == 1)
        // {
        //     Debug.Log("you win");
        // }
        Text s = scoreText.GetComponent<Text>();
        s.text = "Score: " + score.ToString();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 hitPos = Vector3.zero;
        foreach (ContactPoint2D hit in other.contacts)
        {
            hitPos.x = hit.point.x - 0.01f * hit.normal.x;
            hitPos.y = hit.point.y - 0.01f * hit.normal.y;
            if (destroyTiles.GetTile(destroyTiles.WorldToCell(hitPos)))
            {
                restorTiles.Add(destroyTiles.GetTile<Tile>(destroyTiles.WorldToCell(hitPos)));
                locationOf.Add(hitPos);
                destroyTiles.SetTile(destroyTiles.WorldToCell(hitPos), null);
                score++;
            }




        }
    }
    public void resto()
    {
        for (int i = 0; i < restorTiles.Count; i++)
        {
            destroyTiles.SetTile(destroyTiles.WorldToCell(locationOf[i]), restorTiles[i]);
        }
        restorTiles = new List<Tile>();
        locationOf = new List<Vector3>();
        // for (int x = 0; x < area.size.x; x++)
        // {
        //     for (int y = 0; y < area.size.y; y++)
        //     {
        //         TileBase tile = restoreTiles[x + y * area.size.x];
        //         if (tile != null)
        //         {
        //             // Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
        //         }
        //         else
        //         {
        //             Vector3 s = new Vector3(area.size.x,area.size.y,area.size.z);

        //             destroyTiles.SetTile(destroyTiles.WorldToCell(s),tile);
        //         }
        //     }
        // }
    }
    bool isEmpty()
    {
        if(locationOf.Count == 0){
            return false;
        }
        for (int i = 0; i < locationOf.Count; i++)
        {
            if (destroyTiles.GetTile(destroyTiles.WorldToCell(locationOf[i])))
            {
                return false;
            }

        }
        return true;
    }

}
