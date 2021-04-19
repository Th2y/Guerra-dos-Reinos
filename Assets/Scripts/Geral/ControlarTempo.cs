using UnityEngine;

public class ControlarTempo : MonoBehaviour
{
    [SerializeField]
    private Inimigo inimigo;
    private float tempoEspera = 2f;

    [SerializeField]
    private Sortear sortear;
    private float tempoSorteio = 1f;

    private float tempoDecorrido = 0f;

    void Update()
    {
        if (sortear.vezJogador)
            tempoDecorrido += Time.deltaTime;

        if (inimigo.iniciarJogada)
        {
            tempoEspera -= Time.deltaTime;
            if (tempoEspera <= 0)
            {
                sortear.SortearNum();
                tempoEspera = 2f;
            }
        }

        if (sortear.esperarSorteio)
        {
            tempoSorteio -= Time.deltaTime;
            if(tempoSorteio <= 0)
            {
                if (sortear.vezJogador)
                    sortear.Sorteio();
                else
                    sortear.SorteioIA();

                tempoSorteio = 1f;
            }
        }
    }
}
