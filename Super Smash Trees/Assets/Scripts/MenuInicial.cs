using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        StartCoroutine(EjecutarJugarConDelay());
    }

    public void Salir()
    {
        StartCoroutine(EjecutarSalirConDelay());
    }

    IEnumerator EjecutarJugarConDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator EjecutarSalirConDelay()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Salir");
        Application.Quit();
    }
}