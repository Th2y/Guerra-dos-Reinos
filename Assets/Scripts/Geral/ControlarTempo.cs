using UnityEngine;

public class ControlarTempo : MonoBehaviour
{
    [SerializeField]
    private Inimigo inimigo;
    private float tempoEspera = 2f;

    void Update()
    {
        if (inimigo.iniciarJogada)
        {
            Debug.Log(tempoEspera);
            tempoEspera -= Time.deltaTime;
            if (tempoEspera <= 0)
            {
                inimigo.Jogar();
                tempoEspera = 2f;
            }
        }
    }
}
