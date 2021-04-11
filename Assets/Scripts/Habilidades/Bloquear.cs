using UnityEngine;

public class Bloquear : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorBloqueia()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "bloquear";
        for (int i = 0; i < habilidades.casas.Length; i++)
        {
            if (habilidades.casasJogador[i].tipoJogador == TipoJogador.Xis)
                habilidades.casas[i].interactable = false;
            else
                habilidades.casas[i].interactable = true;
        }
    }
}
