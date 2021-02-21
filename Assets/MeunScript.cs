using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MeunScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    // Use this for initialization
    void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }
	
	public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
   
    }
    public void NoPress()
    {

        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    public void startlevel()
    {
        SceneManager.LoadScene("Level 1");

    }
    public void QuitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = true;
    }
    public void NotPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    public void ExitGame()
    {
        Application.Quit();

    }
}
