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




    public void buttonAction1()
    {
        restoreGame = true;
    }


}
