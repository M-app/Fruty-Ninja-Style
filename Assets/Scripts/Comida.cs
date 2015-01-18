using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour {

    public GameObject izquierdaItem; // left part triggered
    public GameObject derechaItem;  // right part triggered
    public GameObject tinta; // splash in the background 

    public float fuerza; // force
    public float torsion; // torsion

    public bool isDead; 
    private Vector3 screen; // posicion en pantalla 
    public float minY; // screen limit Y 
    public float maxY; // screen limit Y 
    public float rotacionDireccion = 50; // direction of rotation
	// Use this for initialization
	void Start () {
        minY = GerenciarCamara.MinY();  
        maxY = GerenciarCamara.MaxY(); 
	}
	
	// Update is called once per frame
	void Update () {
        Remover();
	}
    
    public void Remover()   // method for destroy the game object 
    {
        screen = Camera.main.WorldToScreenPoint(transform.position);
        if (isDead && screen.y < minY)
        {
            Destroy(gameObject);
        }
        else
        {
            isDead = true;
        }
        transform.Rotate(new Vector3(0, 0, rotacionDireccion) * Time.deltaTime);
    }

    public void InstanciarDestruir()    // method for Instantiate all objects and use a force and torsion. 
    {
        GameObject tempItem = null;
        GameObject tempTinta = null;

        tempItem = Instantiate(izquierdaItem, transform.position, transform.rotation) as GameObject;
        tempItem.rigidbody2D.AddForce(-transform.right * fuerza); // use left force 
        tempItem.rigidbody2D.AddTorque(-torsion); // use left torsion

        tempItem = Instantiate(derechaItem, transform.position, transform.rotation) as GameObject;
        tempItem.rigidbody2D.AddForce(transform.right * fuerza); // use right force 
        tempItem.rigidbody2D.AddTorque(torsion); // use right torsion

        tempTinta = Instantiate(tinta, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject; // Instantiante splash in the background 

        Destroy(gameObject); // destroy the game objects. 
    }
}
