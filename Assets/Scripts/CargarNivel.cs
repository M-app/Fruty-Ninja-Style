using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CargarNivel : MonoBehaviour {


	public void LoadScene(int nivel)    // metodo para cargar la escena con el número pasado en el inspector. 
    {                                       // method to load the scene with the last number in the inspector 
        Application.LoadLevel(nivel); 
    }
}
