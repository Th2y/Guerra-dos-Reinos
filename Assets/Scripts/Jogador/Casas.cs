using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    public int numCasa = 0;

    [SerializeField]
    private Image xisImage;
    [SerializeField]
    private Image bolaImage;

    [SerializeField]
    private Interagir interagir;
    [SerializeField]
    private Sortear sortear;
    [SerializeField]
    private Habilidades habilidades;

    public TipoJogador tipoJogador;

    private void Start()
    {
        this.tipoJogador = TipoJogador.Nenhum;
    }

    public void Clicou()
    {
        if (!habilidades.usandoHabilidade || this.tipoJogador == TipoJogador.Nenhum)
        {
            xisImage.gameObject.SetActive(true);
            this.tipoJogador = TipoJogador.Xis;
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SortearNum();
        }
        else UsarHabilidade();

        for (int i = 0; i < habilidades.casasJogador.Length; i++)
        {
            if (habilidades.casasJogador[i].tipoJogador == TipoJogador.Bloqueado)
                habilidades.casasJogador[i].tipoJogador = TipoJogador.Nenhum;
        }
    }
    public void UsarHabilidade()
    {
        if (habilidades.tipoHabilidade == "bloquear")
        {
            this.tipoJogador = TipoJogador.Bloqueado;
        }
        else if (habilidades.tipoHabilidade == "mudar")
        {
            bolaImage.gameObject.SetActive(false);
            xisImage.gameObject.SetActive(true);
            this.tipoJogador = TipoJogador.Xis;
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SortearNum();
        }
        else if (habilidades.tipoHabilidade == "retirar")
        {
            bolaImage.gameObject.SetActive(false);
            this.tipoJogador = TipoJogador.Bloqueado;

            for (int i = 0; i < habilidades.casas.Length; i++)
            {
                if (habilidades.casasJogador[i].tipoJogador != TipoJogador.Nenhum)
                    habilidades.casas[i].interactable = false;
                else
                    habilidades.casas[i].interactable = true;
            }
        }
        habilidades.usandoHabilidade = false;
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
