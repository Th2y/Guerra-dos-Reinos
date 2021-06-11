﻿using UnityEngine;
using UnityEngine.UI;

public class CasasInimigo : MonoBehaviour
{
    [SerializeField]
    private Image bola;
    [SerializeField]
    private Image xis;

    [SerializeField]
    private Casas casasJogador;
    [SerializeField]
    private Sortear sortear;
    [SerializeField]
    private Habilidades habilidades;

    public void Jogar()
    {
        if (sortear.tabuleiro.jogadorDeX)
        {
            casasJogador.tipoJogador = TipoJogador.Bola;
            bola.gameObject.SetActive(true);
        }
        else
        {
            casasJogador.tipoJogador = TipoJogador.Xis;
            xis.gameObject.SetActive(true);
        }
        sortear.PassarVez();
        sortear.sortear[0].interactable = true;

        for (int i = 0; i < habilidades.casasJogador.Length; i++)
        {
            if (habilidades.casasJogador[i].tipoJogador == TipoJogador.BloqueadoPeloJog)
                habilidades.casasJogador[i].tipoJogador = TipoJogador.Nenhum;
        }
    }
}
