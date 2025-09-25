using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
	
    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    
    private Animator animacion;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
	float entradaX = 0f;
	if (Keyboard.current.leftArrowKey.isPressed) entradaX = -1f;
        else if (Keyboard.current.rightArrowKey.isPressed) entradaX = 1f;

	fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocityY);
    }
    
    // Update is called once per frame
    void Update()
    {
    	if (fisica.linearVelocityX > 0){ sprite.flipX= false; }
    	else if (fisica.linearVelocityX < 0) { sprite.flipX = true; }
    	
        if(Keyboard.current.spaceKey.wasPressedThisFrame && TocarSuelo())
        {
        	fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        
        AnimarJugador();
    }
    
    private void AnimarJugador()
    {
    	if(!TocarSuelo()) animacion.Play("jugadorSaltar");
    	else if((fisica.linearVelocityX > 1 || fisica.linearVelocityX < -1) && fisica.linearVelocityY == 0)
    		animacion.Play("jugadorCorrer");
    	else if ((fisica.linearVelocityX < 1 || fisica.linearVelocityX > -1) && fisica.linearVelocityY == 0)
    		animacion.Play("jugadorParado"); 
    
    }
    
    private bool TocarSuelo()
    {
    	RaycastHit2D tocar = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
    	
    	return tocar.collider != null;
    }
}
