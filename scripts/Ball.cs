using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 lastVelocity;
    public bool left, right;
    public GameObject Rightside;
    public GameObject Leftside2;
    public GameObject player;
    public GameObject livesText;
    private static int lives = 3;
    public static bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {


        Vector2 playPos = player.GetComponent<Transform>().position;
        Vector2 cpL = Leftside2.GetComponent<Transform>().position;
        Vector2 cpR = Rightside.GetComponent<Transform>().position;
        Vector2 currentPos = rb.position;
        lastVelocity = rb.velocity;
        if (currentPos.x - 4.0f < cpL.x)
        {
            right = true;
            left = false;
        }
        // if(lives == 0){
        //     lives = 3;
        // }

        if (currentPos.x + 4.0f > cpR.x)
        {
            left = true;
            right = false;
        }
        if (left)
        {
            right = false;
        }
        if (right)
        {
            left = false;
        }
        if (!left && !right)
        {
            transform.Translate(-Vector2.up * 0.5f * Time.deltaTime);

        }
        if (left)
        {
            transform.Translate(Vector2.left * (lastVelocity.magnitude * 0.6f) * Time.deltaTime);
        }
        if (right)
        {
            transform.Translate(Vector2.right * (lastVelocity.magnitude * 0.6f) * Time.deltaTime);
        }
        if (currentPos.y < (playPos.y) - 8.0f)
        {
            Vector2 temp = currentPos;
            temp.x = -5;
            temp.y = -12;
            transform.position = temp;
            lives -= 1;
            Text live = livesText.GetComponent<Text>();
            live.text = "lives: " + lives.ToString();
            left = false;
            right = false;
            rb.velocity = rb.velocity / 3;
            dead = true;

        }



    }
    void fixedUpdate()
    {
        lastVelocity = rb.velocity;
        if (rb.velocity.magnitude < 4)
        {
            rb.velocity = rb.velocity * 2.0f;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 surfaceNormal = other.contacts[0].normal;
        if (rb.velocity.magnitude > 25)
        {

            lastVelocity = rb.velocity / 2.0f;
        }

        int r = Random.Range(0, 2);

        if (!left && !right)
        {
            if (r >= 1)
            {
                left = true;
            }
            else
            {
                right = true;
            }
        }
        else
        {
            int s = Random.Range(0, 4);
            if (s >= 2)
            {
                if (left)
                {
                    right = true;
                    left = false;
                }
                else
                {
                    right = false;
                    left = true;
                }
            }

        }
        if (other.gameObject.name.Contains("sidehit"))
        {
            Debug.Log("s");

        }

        rb.velocity = Vector2.Reflect(lastVelocity * 1.6f, surfaceNormal);

    }
    public static bool isAtZero()
    {
        return lives < 0;
    }
    public static void reset(){
        lives = 3;
    }
}
