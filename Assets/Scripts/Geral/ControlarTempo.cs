using UnityEngine;

public class ControlarTempo : MonoBehaviour
{
    [SerializeField]
    private Inimigo inimigo;
    private float tempoEspera = 2f;

    [SerializeField]
    private Sortear sortear;
    private float tempoSorteio = 1f;

    void Update()
    {
        if (inimigo.iniciarJogada)
        {
            tempoEspera -= Time.deltaTime;
            if (tempoEspera <= 0)
            {
                inimigo.Jogar();
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
