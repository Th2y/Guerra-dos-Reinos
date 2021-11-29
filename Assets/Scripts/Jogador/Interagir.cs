using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    private AssociacaoCasas associacaoCasas;
    [SerializeField]
    private Sortear sortear;

    private void Start()
    {
        for (int i = 0; i < associacaoCasas.casas.Length; i++)
        {
            associacaoCasas.casasJogador[i].numCasa = i;
        }

        Bloquear(sortear.tabuleiro.jogadorDeX);
    }

    public void Bloquear(bool bloqueio)
    {
        for (int i = 0; i < associacaoCasas.casas.Length; i++)
        {
            if (sortear.vezJogador)
            {
                if (associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.Nenhum ||
                    associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.BloqueadoPeloJog)
                {
                    associacaoCasas.casas[i].interactable = bloqueio;
                    associacaoCasas.casasJogador[i].tipoJogador = TipoJogador.Nenhum;
                }                    
                else
                    associacaoCasas.casas[i].interactable = false;
            }
            else
            {
                if (associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.Nenhum ||
                    associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.BloqueadoPelaIA)
                {
                    associacaoCasas.casas[i].interactable = bloqueio;
                    associacaoCasas.casasJogador[i].tipoJogador = TipoJogador.Nenhum;
                }
                else
                    associacaoCasas.casas[i].interactable = false;
            }
        }
    }
}
