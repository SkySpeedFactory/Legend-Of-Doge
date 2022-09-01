using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeScene", 18f);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
