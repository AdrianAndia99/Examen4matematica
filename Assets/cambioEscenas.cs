using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscenas : MonoBehaviour
{
    public void Scene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
