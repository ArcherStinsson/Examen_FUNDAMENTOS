using UnityEngine;
using Unity.Cinemachine;

public class Cinemachine : MonoBehaviour
{
    public CinemachineCamera camJugador;
    public CinemachineCamera camAmplia;
    private bool vistaAmplia = false;

    void Start()
    {
        camJugador.Priority = 10;
        camAmplia.Priority = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            vistaAmplia = !vistaAmplia;
            if (vistaAmplia)
            {
                camJugador.Priority = 5;
                camAmplia.Priority = 10;
            }
            else
            {
                camJugador.Priority = 10;
                camAmplia.Priority = 5;
            }
        }
    }
}