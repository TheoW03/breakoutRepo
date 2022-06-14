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
    public GameObject deadPanel;
    public GameObject youWinPanel;
    public static bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        youWinPanel.SetActive(false);
        deadPanel.SetActive(false);
        destroyTiles = GetComponent<Tilemap>();
        area = destroyTiles.cellBounds;

    }

    // Update is called once per frame
    void Update()
    {
        restoreTiles = destroyTiles.GetTilesBlock(area);
        if (locationOf.Count >= 92)
        {
            win = true;
            youWinPanel.SetActive(true);
            if (ButtonActions.restoreGame)
            {
                resto();
                score = 0;
                Ball.reset();
                youWinPanel.SetActive(false);
                ButtonActions.restoreGame = false;
            }
            return;
        }
        if (Ball.isAtZero())
        {
            deadPanel.SetActive(true);
            Text t = GameObject.Find("ScoreText").GetComponent<Text>();
            t.text = "Score: " + score.ToString();
            if (ButtonActions.restoreGame)
            {
                resto();
                score = 0;
                Ball.reset();
                deadPanel.SetActive(false);
                ButtonActions.restoreGame = false;
            }
            return;

        }
        TileBase[] tileArray = destroyTiles.GetTilesBlock(area);
        // bool isEmpty =  tileArray.All(x => !x.HasValue);
        // if (isEmpty<TileBase>(tileArray))
        // {
        //     Debug.Log("you win");
        // }

        // if (!isEmpty())
        // {
        //     Debug.Log("you win");
        // }
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

    }
    // bool isEmpty()
    // {
    //     // if (locationOf.Count == 0)
    //     // {
    //     //     return false;
    //     // }
    //     foreach (var position in destroyTiles.cellBounds.allPositionsWithin)
    //     {
    //         if (destroyTiles.HasTile(position))
    //         {
    //             return true;
    //         }

    //         // Tile is not empty; do stuff
    //     }
    //     return false;
    // }

}
