using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public Vector2 buttonPos;

    void Update()
    {
        buttonPos = button.GetComponent<Transform>().position;
        // Debug.Log("mouse "+Input.mousePosition);

        // Debug.Log("button: "+buttonPos);
        bool isOn =
        System.Math.Round(buttonPos.x) - 20 > System.Math.Round(Input.mousePosition.x)
        ||
        System.Math.Round(buttonPos.x) + 20 < System.Math.Round(Input.mousePosition.x)
        &&
        System.Math.Round(buttonPos.y) - 20 > System.Math.Round(Input.mousePosition.y)
        ||
        System.Math.Round(buttonPos.y) + 20 < System.Math.Round(Input.mousePosition.y);
        // Debug.Log(isOn);
        // isOn = false;
        if (isOn)
        {
            button.GetComponent<Text>().color = Color.white;
            button.GetComponent<Text>().text = "start";
        }
        else
        {
            
            button.GetComponent<Text>().color = Color.yellow;
             button.GetComponent<Text>().text = ">start<";
        }

    }


}
