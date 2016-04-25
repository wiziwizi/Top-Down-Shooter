using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneHandler : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas optionMenu;
	public Button startText;
	public Button exitText;

	void Start()
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		optionMenu = optionMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();

		quitMenu.enabled = false;
		optionMenu.enabled = false;

	}
	public void NewGame()
	{
		SceneManager.LoadScene ("Main");
	}

	public void OptionMenu()
	{
		optionMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void QuitMenu()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void ExitQuitMenu()
	{
		optionMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}