using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Variable tipo GameObject para hacer referencia al prefab de la bala
    // Nunca meter un objeto de la escena aqu�
    public GameObject ballPrefab;
    // Variable tipo transform para posicionar los clones del prefab
    public Transform posBall;
    // Otra opci�n es hacer referencia al gameobject y luego a su
    // componente transform, aunque se da m�s rodeo.
    // public GameObject posBall2;

    // Tiempo asignado antes que se destruya el objeto. Buena pr�ctica para el rendimiento del juego.
    public float timeToDestroy = 3;

    // Solo vas a poder atacar si ha pasado x tiempo antes de tu �ltimo ataque
    public float timeBetweenAttacks;

    // Contador de tiempo
    float timer; 

    // Start is called before the first frame update
    void Start()
    {
        // Espa�a.Andaluc�a.M�laga
        // GameObject.transform.position

        // Mostramos la posici�n del prefab a trav�s de su componente transform
        // Debug.Log("PosBall: " + posBall.position);
        // Mostramos la posici�n del prefab a trav�s de su GameObject posBall
        // Debug.Log("PosBall: " + posBall2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // En cada frame el timer va a ser igual que el valor que ten�a acumulado + Time.deltaTime
        timer += Time.deltaTime; // contador 0, 1, 2,...
        // Debug.Log("Timer " + timer);

        // 
        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenAttacks)
        {
            CreateBalls();
        }
    }

    void CreateBalls()
    {
        // En la misma l�nea declaramos la variable y le damos un valor
        // Creamos clones de un prefab y lo guardamos en una variable local tipo GameObject
        GameObject cloneBallPrefab = Instantiate(ballPrefab, posBall.position, posBall.rotation);

        // Llamamos al componente Ball (script) de los clones del prefab
        // Le damos direcci�n a la bala a trav�s del eje Z del gO que lleva este
        // script, que en este caso lo lleva el Player
        cloneBallPrefab.GetComponent<Ball>().direction = transform.forward;

        Destroy(cloneBallPrefab, timeToDestroy);
    }
}
