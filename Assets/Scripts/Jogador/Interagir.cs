using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    private Button[] casas;
    [SerializeField]
    private Casas[] casasJogador;

    private void Start()
    {
        Bloquear(true);
    }

    public void Bloquear(bool bloqueio)
    {
        for (int i = 0; i < casas.Length; i++)
        {
            if(casasJogador[i].tipoJogador == TipoJogador.Nenhum)
                casas[i].interactable = bloqueio;
            else
                casas[i].interactable = false;
        }
    }
}
