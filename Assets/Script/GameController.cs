using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject PauseButton;
    public GameObject GameOverPanel;
    public GameObject LevelCompletePanel;
    public GameObject EndText;
    int currentindex;
    // Start is called before the first frame update
    void Start()
    {
        currentindex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        GameOverPanel.SetActive(false);
        Pausemenu.SetActive(false); 
        PauseButton.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void PauseGame()
    {
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Gameover()
    {
        GameOverPanel.SetActive(true);
        PauseButton.SetActive(false);
    }
    
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        EndText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        LevelCompletePanel.SetActive(true);

    }
    public void StartButton()
    {
        SceneManager.LoadScene(0);  
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
    

