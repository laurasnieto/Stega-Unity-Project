using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;

    int numCoins;

    // M�todo p�blico que va a ser llamado desde el script del Player cuando este coja una moneda (onTrigger)
    public void AddCoin()
    {
        numCoins++; // Sumo 1
        // Accedemos a la propiedad Text del componente TextMesh para editar el texto.
        textCoin.text = "" + numCoins.ToString(); // El m�todo .ToString() transforma el int en string
    }

}
