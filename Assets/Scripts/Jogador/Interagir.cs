using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    private AssociacaoCasas associacaoCasas;

    private void Start()
    {
        for (int i = 0; i < associacaoCasas.casas.Length; i++)
        {
            associacaoCasas.casasJogador[i].numCasa = i;
        }

        Bloquear(true);
    }

    public void Bloquear(bool bloqueio)
    {
        for (int i = 0; i < associacaoCasas.casas.Length; i++)
        {
            if(associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.Nenhum)
                associacaoCasas.casas[i].interactable = bloqueio;
            else
                associacaoCasas.casas[i].interactable = false;
        }
    }
}
