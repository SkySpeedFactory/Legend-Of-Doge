using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    bool isPaused;
    bool isActive;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject deathPanel;
    [SerializeField] AudioSource bgm;

    [SerializeField] Slider volumeSlider;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                pausePanel.SetActive(true);
                
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                pausePanel.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
    public void DeathPanel()
    {
        deathPanel.SetActive(true);
        
    }
    public void ChangeSoundVolume()
    {         
        bgm.volume = volumeSlider.value;

        if (Input.GetButtonDown("Horizontal"))
        {
            bgm.volume -= 0.1f;
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            bgm.volume += 0.1f;
        }
    }
    public void PlayGame() 
    { 
        SceneManager.LoadScene(3);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        if (!isPaused)
        {                        
            Time.timeScale = 0;
            isPaused = true;
            pausePanel.SetActive(true);
        }
        else
        {            
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
        }
    }

    public void PressButtonSound(int index)
    {
        SoundManager.instance.PlaySound(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void SettingsPanelOn()
    {
        settingsPanel.SetActive(true);           
    }
    public void SettingsPanelOff()
    {
        settingsPanel.SetActive(false);
    }
}
