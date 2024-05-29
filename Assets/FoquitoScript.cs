using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    public GameObject[] colors; // array de objetos que se llama colors (manera de almacenar elementos de un mismo tipo, en este caso gameobjects)
    public int currentLightIndex =-1; // variable de enteros que la inicializo en -1, voy a almacenar a que color me refiero en ese momento

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight() // activas un cubito, despues el otro, etc
    {
        currentLightIndex++; // se esta incrementando en uno la variable, en primera instancia estaria en 0 (1er elemen del array)
        if (currentLightIndex >= colors.Length) // es mayor o igual a la cantidad de elementos que tiene el array colors. 
        {
            currentLightIndex = 0; // si es mayor o igual te pasas, entonces vuelve a 0 (1er elemento del array)
        }
        DeactivateAllLights(); // va a llamar a esta funcion (desactiva todas las luces)
        colors[currentLightIndex].SetActive(true); // activa solamente al que corresponde al currentLightIndex (o sea la proxima luz)
    }

    public void ActivatePreviousLight() // para activar a la anterior
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in colors) // desactiva todas las luces
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        InvokeRepeating(nameof(ActivateNextLight),0,t); // InvokeRepeating: para la repeticion
    }
}
