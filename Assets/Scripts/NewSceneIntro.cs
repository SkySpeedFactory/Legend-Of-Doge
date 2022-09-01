using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewSceneIntro : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeScene", 70.5f);
    }

    
    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
}
