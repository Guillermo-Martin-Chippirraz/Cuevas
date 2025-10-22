using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlBala : MonoBehaviour
{
    public float velocidad;
    public float daño;
    public float tiempoDeVida;
    [HideInInspector] public Vector2 direccion = Vector2.right;
    
    private Animator anim;
    
    private void Start()
    {
    	anim = GetComponent<Animator>();
    	if(anim != null)
    	{
    		anim.Play("Shot");
    	}
    	
    	Destroy(gameObject, tiempoDeVida);
    }
    
    private void Update()
    {
    	transform.Translate(direccion*velocidad*Time.deltaTime);

    }
    
    private void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Enemigo"))
    	{
    		other.GetComponent<ControlEnemigo>().TomarDaño(daño);
    		Destroy(gameObject);
    	}
    }
    
}
