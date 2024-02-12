using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
