using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlEnemigo : MonoBehaviour
{

	public float velocidad;
	public Vector3 posicionFin;
	
	private Vector3 posicionInicio;
	private bool moviendoAFin;
	
	private Animator animacion;
	private Vector3 posicionAnterior;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
        animacion = GetComponent<Animator>();
        posicionAnterior = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
        AnimarEnemigo();
        posicionAnterior = transform.position;
    }
    
    private void AnimarEnemigo(){
    
    	Vector3 direccion = transform.position - posicionAnterior;
    
    	float velocidadActual = (transform.position - posicionAnterior).magnitude / Time.deltaTime;
    	
    	if(velocidadActual > 0.01f){
    	
    		animacion.Play("crabWalk");
    		
    		if(direccion.x > 0) transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    		else if (direccion.x < 0) transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
    	}
    	else animacion.Play("crabIdle");
   		
    }
    private void MoverEnemigo()
    {
    	Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;
    	
    	transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);
    	if(transform.position == posicionFin) moviendoAFin = false;
    	if(transform.position == posicionInicio) moviendoAFin = true;
    }
}
