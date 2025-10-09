using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlEnemigo : MonoBehaviour
{

	public float velocidad;
	public Vector3 posicionFin;
	private Vector3 posicionInicio;
	private bool moviendoAFin;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
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
    }
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.gameObject.CompareTag("Player"))
    	{
    		collision.gameObject.GetComponent<ControlJugador>().QuitarVida();
    	}
    }
}
