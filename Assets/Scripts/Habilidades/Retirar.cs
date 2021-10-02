using UnityEngine;

public class Retirar : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorRetira()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "retirar";
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

    public void IARetira()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "retirar";
    }
}
