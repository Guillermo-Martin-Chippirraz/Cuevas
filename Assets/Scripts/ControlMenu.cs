using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ControlMenu : MonoBehaviour
{

	public void OnBotonJugar()
	{
		
        SceneManager.LoadScene("Nivel1");
        
	}
	
	public void OnBotonExit()
	{
		Application.Quit();
	}
	
	public void OnBotonCreditos()
	{
		SceneManager.LoadScene("creditos");
	}
	
	public void OnBotonMenu()
	{
		SceneManager.LoadScene("comienzo");
	}
}
