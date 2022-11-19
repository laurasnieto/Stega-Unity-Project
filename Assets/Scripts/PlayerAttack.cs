using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Variable tipo GameObject para hacer referencia al prefab de la bala
    // Nunca meter un objeto de la escena aquí
    public GameObject ballPrefab;
    // Variable tipo transform para posicionar los clones del prefab
    public Transform posBall;
    // Otra opción es hacer referencia al gameobject y luego a su
    // componente transform, aunque se da más rodeo.
    // public GameObject posBall2;

    // Tiempo asignado antes que se destruya el objeto. Buena práctica para el rendimiento del juego.
    public float timeToDestroy = 3;

    // Solo vas a poder atacar si ha pasado x tiempo antes de tu último ataque
    public float timeBetweenAttacks;

    // Contador de tiempo
    float timer; 

    // Start is called before the first frame update
    void Start()
    {
        // España.Andalucía.Málaga
        // GameObject.transform.position

        // Mostramos la posición del prefab a través de su componente transform
        // Debug.Log("PosBall: " + posBall.position);
        // Mostramos la posición del prefab a través de su GameObject posBall
        // Debug.Log("PosBall: " + posBall2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // En cada frame el timer va a ser igual que el valor que tenía acumulado + Time.deltaTime
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
        // En la misma línea declaramos la variable y le damos un valor
        // Creamos clones de un prefab y lo guardamos en una variable local tipo GameObject
        GameObject cloneBallPrefab = Instantiate(ballPrefab, posBall.position, posBall.rotation);

        // Llamamos al componente Ball (script) de los clones del prefab
        // Le damos dirección a la bala a través del eje Z del gO que lleva este
        // script, que en este caso lo lleva el Player
        cloneBallPrefab.GetComponent<Ball>().direction = transform.forward;

        Destroy(cloneBallPrefab, timeToDestroy);
    }
}
