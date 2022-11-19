using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int turnSpeed;

    // OPT 1: variable tipo GameObject
    // public GameObject gameManager;
    // OPT 2: variable tipo GameManager (RECOMENDADO)
    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // OPT 1: Accedemos al componente script GameManager para editar su método AddCoin()
            // gameManager.GetComponent<GameManager>().AddCoin(); // gameManager es una variable tipo GameObject
            // OPT 2: Accedemos al método AddCoin directamente desde el script GameManager (RECOMENDADO)
            gameManagerScript.AddCoin(); // gameManagerScript es una variable tipo GameManager

            gameObject.SetActive(false);
        }
    }
}
