using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void loadTutorial()
    {
        SceneManager.LoadScene("help");
    }
    public void loadCreds()
    {
        SceneManager.LoadScene("Credits");
    }


}
