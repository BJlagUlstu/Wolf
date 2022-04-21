using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void Update()
    {
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}