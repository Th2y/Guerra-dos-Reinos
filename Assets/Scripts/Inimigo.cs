using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private int casaJogar;

    private TipoJogador tipoJogador;
    public static Inimigo instancia;

    private void Awake()
    {
        this.tipoJogador = TipoJogador.Nenhum;
    }

    private void Start()
    {
        instancia = this;
    }

    public void Jogada()
    {
        casaJogar = Random.Range(0, 8);

        if (this.tipoJogador == TipoJogador.Nenhum)
        {
            this.tipoJogador = TipoJogador.Bola;
            Sortear.instancia.PassarVez();
            Interagir.instancia.Bloquear(true);
            Sortear.instancia.Sorteio();
        }
    }

    public TipoJogador TipoJogador
    {
        get
        {
            return this.tipoJogador;
        }
        set
        {
            this.tipoJogador = value;
        }
    }
}
