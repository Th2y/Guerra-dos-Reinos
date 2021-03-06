using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private int casaJogar;

    public void Jogada()
    {
        casaJogar = Random.Range(0, 8);

        Sortear.instancia.PassarVez();
    }
}
