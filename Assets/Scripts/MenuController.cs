using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void load1to1()
    {
        SceneManager.LoadScene(1);
    }

    public void load1toN()
    {
        SceneManager.LoadScene(2);
    }
}
