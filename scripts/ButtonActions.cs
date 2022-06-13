using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonActions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buton1;
    private Vector2 buttonPos1;

    public GameObject button2;
    private Vector2 buttonPos2;
    public GameObject button3;
    private Vector2 buttonPos3;
    public GameObject button4;
    private Vector2 buttonPos4;
    public static bool restoreGame = false;

    void Update()
    {
        if (checkIfMouse(buttonPos1))
        {
             buton1.GetComponent<Text>().color = Color.white;
            buton1.GetComponent<Text>().text = "play again";
           
        }
        else
        {
            buton1.GetComponent<Text>().color = Color.yellow;
            buton1.GetComponent<Text>().text = ">play again<";

        }

        if (checkIfMouse(buttonPos2))
        {
            button2.GetComponent<Text>().color = Color.white;
            button2.GetComponent<Text>().text = "menu";

        }
        else
        {
            button2.GetComponent<Text>().color = Color.yellow;
            button2.GetComponent<Text>().text = ">menu<";
        }
        if (checkIfMouse(buttonPos3))
        {

        }
        if (checkIfMouse(buttonPos4))
        {

        }


    }


    public void buttonAction1()
    {
        restoreGame = true;
    }
    public bool checkIfMouse(Vector2 buttonPos)
    {
        bool isOn =
       System.Math.Round(Input.mousePosition.x) >= System.Math.Round(buttonPos.x) - 10
       ||
       System.Math.Round(Input.mousePosition.x) <= System.Math.Round(buttonPos.x) + 10
       &&
        System.Math.Round(Input.mousePosition.y) >= System.Math.Round(buttonPos.y) - 10
       ||
       System.Math.Round(Input.mousePosition.y) <= System.Math.Round(buttonPos.y) + 10;
        return isOn;
    }

}
