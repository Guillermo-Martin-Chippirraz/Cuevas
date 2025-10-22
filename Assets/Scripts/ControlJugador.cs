using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    public int numVidas;
	public int puntuacion;
	
    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    
    private Animator animacion;
    
    public Canvas canvas;
    private ControlHud hud;
   	
   	private bool vulnerable;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
        hud = canvas.GetComponent<ControlHud>();
        
        vulnerable = true;
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
    
    public void FinJuego()
    {
    	SceneManager.LoadScene("creditos");
    	//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void IncrementarPuntos(int cantidad)
    {
    	puntuacion += cantidad;
    	hud.SetPuntuacionTxt(puntuacion);
    	hud.SetPowerUpTxt(hud.GetPowerUpTxt() - 1);
    }
    
    public void QuitarVida()
    {
    	if(vulnerable)
    	{
    		vulnerable = false;
    		numVidas--;
    		hud.SetVidasTxt(numVidas);
    		if(numVidas == 0) FinJuego();
    		Invoke("HacerVulnerable", 1f);
    		sprite.color = Color.red;
    	}
    }
    
    private void HacerVulnerable()
    {
    	vulnerable = true;
    	sprite.color = Color.white;
    }
}
