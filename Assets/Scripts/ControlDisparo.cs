using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ControlDisparo : MonoBehaviour
{
    public Transform disparo;
    
    public GameObject bala;
    private SpriteRenderer sprite;
    
    private void Start()
    {
    	sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update(){
    	if(Keyboard.current.zKey.wasPressedThisFrame){
    		Disparar();
    	}
    }
    
    private void Disparar(){
    
    	try
    	{
    		if(bala == null)
    		{
    			return;
    		}
			GameObject nuevaBala = Instantiate(bala, disparo.position, Quaternion.identity);
			
			if(nuevaBala.GetComponent<ControlBala>() != null)
			{
				if(sprite.flipX)
				{
					nuevaBala.transform.localScale = new Vector3(-1, 1, 1);
					nuevaBala.GetComponent<ControlBala>().direccion = Vector2.left;
				}
				else
				{
					nuevaBala.transform.localScale = new Vector3(1, 1, 1);
					nuevaBala.GetComponent<ControlBala>().direccion = Vector2.right;
				}
			}
			else
			{
				Debug.LogWarning("La bala instanciada no tiene el script ControlBala");
			}
		}
    	catch (System.Exception ex)
    	{
    		Debug.LogError("Error al disparar: " + ex.Message);
    	}
    }
}
