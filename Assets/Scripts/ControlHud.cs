using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ControlHud : MonoBehaviour
{
	public TextMeshProUGUI VidasTexto;
	public TextMeshProUGUI PowerUpTexto;
	public TextMeshProUGUI PuntuacionTexto;
	
	public void SetVidasTxt(int vidas)
	{
		VidasTexto.text = "Vidas: " + vidas;
	}
	
	public void SetPowerUpTxt(int cantidad)
	{
		PowerUpTexto.text = "PowerUps: " + cantidad;
	}
	
	public void SetPuntuacionTxt(int puntuacion)
	{
		PuntuacionTexto.text = "Puntuación: " + puntuacion;
	}
}
