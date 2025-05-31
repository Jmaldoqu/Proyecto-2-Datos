using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    public GameObject personaje1Prefab;
    public GameObject personaje2Prefab;

    private int jugadoresUnidos = 0;

    void Start()
    {
        // Desactivar auto-join
        PlayerInputManager.instance.DisableJoining();
    }

    void Update()
    {
        // Detectar mandos (Gamepad 1 y 2)
        if (Gamepad.all.Count > jugadoresUnidos && jugadoresUnidos < 2)
        {
            if (Gamepad.all[jugadoresUnidos].startButton.wasPressedThisFrame)
            {
                CrearJugador(jugadoresUnidos, Gamepad.all[jugadoresUnidos]);
                jugadoresUnidos++;
            }
        }

        // Detectar teclado (por ejemplo, barra espaciadora)
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && jugadoresUnidos < 2)
        {
            CrearJugador(jugadoresUnidos, Keyboard.current);
            jugadoresUnidos++;
        }
    }

    void CrearJugador(int index, InputDevice dispositivo)
    {
        GameObject prefabAInstanciar = (index == 0) ? personaje1Prefab : personaje2Prefab;
        PlayerInputManager.instance.playerPrefab = prefabAInstanciar;
        PlayerInputManager.instance.JoinPlayer(index, -1, null, dispositivo);
    }

}