using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    public void play(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void quit(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void OnPlayAgainClicked()
    {
        // Quay lại scene cũ
        SceneManager.LoadScene(GameData.LastScene);
    }
    

}
