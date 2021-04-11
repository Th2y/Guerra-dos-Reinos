using UnityEngine;

public class Mudar : MonoBehaviour
{
    [SerializeField]
    private Habilidades habilidades;

    public void JogadorMuda()
    {
        habilidades.usandoHabilidade = true;
        habilidades.tipoHabilidade = "mudar";
        for (int i = 0; i < habilidades.casas.Length; i++)
        {
            if (habilidades.casasJogador[i].tipoJogador == TipoJogador.Xis)
                habilidades.casas[i].interactable = false;
            else
                habilidades.casas[i].interactable = true;
        }
    }
}
