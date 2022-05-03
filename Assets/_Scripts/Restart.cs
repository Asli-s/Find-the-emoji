using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartScene()
    {
       // StopCoroutine(_board.StartTimer);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}
