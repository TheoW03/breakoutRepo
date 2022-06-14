using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Rightside;
    public GameObject Leftside2;
    public GameObject pauseGame;
    public static bool onPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseGame.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && onPaused)
        {
            pauseGame.SetActive(false);
            onPaused = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !onPaused)
        {
            pauseGame.SetActive(true);
            onPaused = true;
            Time.timeScale = 0;
        }
        if(!onPaused){
            pauseGame.SetActive(false);
            onPaused = false;
            Time.timeScale = 1;
        }
        Vector2 currentPos = rb.position;
        // if(Ball.isAtZero()){
        //     return;
        // }
        if (Ball.dead)
        {
            Vector2 temp = currentPos;
            temp.x = -5;
            transform.position = temp;
            Ball.dead = false;
        }
        Vector2 cpL = Leftside2.GetComponent<Transform>().position;
        Vector2 cpR = Rightside.GetComponent<Transform>().position;
        if (!onPaused)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * 1.0f);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-Vector2.right * 1.0f);
            }
        }



        if (currentPos.x > cpL.x || currentPos.x < cpR.x)
        {
            Vector2 s = rb.position;
            if (currentPos.x + 8.0f > cpR.x)
            {
                s.x -= 1.0f;
                transform.position = s;

            }
            if (currentPos.x - 8.0f < cpL.x)
            {
                s.x += 1.0f;
                transform.position = s;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        // Vector2 surfaceNormal = other.contacts[0].normal;
        if (other.gameObject.name == "sideHit")
        {
            Vector2 t = transform.position;
            t.x -= 1.0f;
            transform.position = t;
        }
        else if (other.gameObject.name == "sideit (1)")
        {
            Vector2 t = transform.position;
            t.x += 1.0f;
            transform.position = t;
        }

        // rb.velocity = Vector2.Reflect(Vector2.zero, surfaceNormal);
    }
}


