using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase que controla la fuerza de impulso de la bola
/// </summary>
public class Ball : MonoBehaviour
{
    public Material mat;

    Rigidbody rb;

    public float force;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * force);
    }

    // Colisiones físicas
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Ha habido una colisión con algo");

        // Cuando este objeto (ball) colisiona con otro accede a su etiqueta y
        // si ese tag es Enemy destruimos el gameObject
        if (collision.collider.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);

            // Guardamos en una variable local el gameObject con el que estoy colisionando 
            GameObject cubeEnemy = collision.gameObject;
            cubeEnemy.GetComponent<MeshRenderer>().material = mat;
        }

    }

    // Método para colisión onTrigger en el que se atraviesa el target
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.CompareTag("Enemy"))
        {
            GameObject cubeEnemy = other.gameObject;
            cubeEnemy.GetComponent<MeshRenderer>().material = mat;
        }
    }
}

    /*
    private void OnCollisonStay(Collision collision)
    {
        Debug.Log("Mientras estén colisionando");
    }

    private void OnCollisonExit(Collision collision)
    {
        Debug.Log("Cuando deja de producirse la colisión");
    }
    */

