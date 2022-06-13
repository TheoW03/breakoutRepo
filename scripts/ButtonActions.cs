using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool restoreGame = false;
    public void buttonAction1(){
        restoreGame = true;
    }

}
