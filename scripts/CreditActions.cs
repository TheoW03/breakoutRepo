using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditActions : MonoBehaviour
{
    // Start is called before the first frame update
    public void goBack()
    {
        SceneManager.LoadScene("mainmenu");

    }
}
