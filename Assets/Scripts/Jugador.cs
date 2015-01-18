using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    public Text puntuacionFinal; // Final Score UI
    public Button botonReintentar;  // Button Try Again 
    public Image imagenGameOver;    // Image Game Over
    public Text textoGameOver;   // text Game Over
    private Vector3 posicion; // screen position
  
    
    public AudioClip clipComida; // Audio Clip Cut Tomatoe, pumpkin, etc. 
    public AudioClip clipZanahoria; // Audio clip cut carrots; 
    public Text text; // Score Text see update
    public Slider slider;  // slider of life
    private int puntuacion; // score
   
    TrailRenderer rastro; // effect of trace wite 
	// Use this for initialization
  
        
    
	void Start () {
        rastro = this.GetComponent<TrailRenderer>() as TrailRenderer;
        rastro.sortingLayerName = "Detalles"; // name the trace 
        imagenGameOver.enabled = false; // disable Image Game over
        botonReintentar.active = false;  // disable buton try again
	}
    
	
	// Update is called once per frame
	void Update () {
        Plataforma();
        text.text = "SCORE: " + puntuacion; // Score update Text. 
       
	}

    private void Plataforma()
    {
        if(Application.platform == RuntimePlatform.Android) // run android
        {

            if (Input.touchCount == 1)
            {
                posicion = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,1)); // z not use because the game is 2D

                transform.position = new Vector2(posicion.x, posicion.y); // finger touch position
                collider2D.enabled = true; // touch is true
                return;
            }
            collider2D.enabled = false; // touch is false 
        } else
        {
            posicion = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0)); // mouse position running in pc

            transform.position = new Vector2(posicion.x, posicion.y); 
        }
     }
    void OnTriggerEnter2D(Collider2D collisor) // if touch the carrots 
    {
        if(collisor.tag== "Zanahoria")
        {
            collisor.GetComponent<Comida>().InstanciarDestruir(); 
            Audio(clipZanahoria); // play sound 
            puntuacion += 10;    // score 
             
        }
        else if(collisor.tag == "Comida") // if touch meal 
        {
            Audio(clipComida); // play meal sound 
            collisor.GetComponent<Comida>().InstanciarDestruir(); // destroy game objets 
            
            slider.value -= 10; // scoore --
            if(slider.value == 0)
            {
                imagenGameOver.enabled = true; // Image Game over enable 
                textoGameOver.text = "GAME OVER"; // Text game ove enable 
                botonReintentar.active = true; // button try again enable 
                puntuacionFinal.text = "" + puntuacion;  // print scoore
            }
           
        }
    }

    void Audio(AudioClip clip) // method use to audio
    {
        audio.clip = clip;
        AudioSource.PlayClipAtPoint(clip, transform.position, 0.2f);
    }
  
    
    
       
   
    
}
