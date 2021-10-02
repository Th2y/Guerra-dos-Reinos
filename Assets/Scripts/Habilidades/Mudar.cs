using UnityEngine;

public class Mudar : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorMuda()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "mudar";
        for (int i = 0; i < habilidades.associacaoCasas.casas.Length; i++)
        {
            if (habilidades.tabuleiro.jogadorDeX)
            {
                if (habilidades.associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.Xis)
                    habilidades.associacaoCasas.casas[i].interactable = false;
                else
                    habilidades.associacaoCasas.casas[i].interactable = true;
            }
            else
            {
                if (habilidades.associacaoCasas.casasJogador[i].tipoJogador == TipoJogador.Bola)
                    habilidades.associacaoCasas.casas[i].interactable = false;
                else
                    habilidades.associacaoCasas.casas[i].interactable = true;
            }
        }
    }
}
