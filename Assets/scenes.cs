
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenes : MonoBehaviour
{
    public int SceneNumber = 1;
    public void LoadNextScene()

        {

   
        SceneManager.LoadScene(SceneNumber);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

   