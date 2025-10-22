using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlEnemigo : MonoBehaviour
{

	public float velocidad;
	public float vida;
	public Vector3 posicionFin;
	private Vector3 posicionInicio;
	private bool moviendoAFin;
	private Animator anim;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
        anim = GetComponent<Animator>();
        if(anim != null)
        {
        	anim.Play("crabIdle");
        }
        else
        {
        	Debug.LogWarning("Animator no encontrado en el enemigo.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    	MoverEnemigo();
    }
    
    
    private void MoverEnemigo()
    {
    	Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;
    	
    	transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);
    	if(transform.position == posicionFin) moviendoAFin = false;
    	if(transform.position == posicionInicio) moviendoAFin = true;
    	
    	if(anim != null && !anim.GetCurrentAnimatorStateInfo(0).IsName("crabWalk")){
    		anim.Play("crabWalk");
    	}
    }
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.gameObject.CompareTag("Player"))
    	{
    		collision.gameObject.GetComponent<ControlJugador>().QuitarVida();
    	}
    }
    
    public void TomarDaño(float daño){
    	
    	vida -= daño;
    	
    	if(vida <= 0){
    		Muerte();
    	}
    }
    
    private void Muerte(){
    	if(anim != null){
    		anim.Play("crabDies");
    	}

    	Destroy(gameObject, 0.5f);
    }
}
