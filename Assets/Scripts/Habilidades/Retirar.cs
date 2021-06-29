using UnityEngine;

public class Retirar : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorRetira()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "retirar";
        for (int i = 0; i < habilidades.casas.Length; i++)
        {
            if (habilidades.tabuleiro.jogadorDeX)
            {
                if (habilidades.casasJogador[i].tipoJogador == TipoJogador.Xis)
                    habilidades.casas[i].interactable = false;
                else
                    habilidades.casas[i].interactable = true;
            }
            else
            {
                if (habilidades.casasJogador[i].tipoJogador == TipoJogador.Bola)
                    habilidades.casas[i].interactable = false;
                else
                    habilidades.casas[i].interactable = true;
            }            
        }
    }

    public void IARetira()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "retirar";
    }
}
