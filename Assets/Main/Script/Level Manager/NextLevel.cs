using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
      public void OnNextClick(){
        SceneManager.LoadScene(staticLevelData.currentLevel);
    }
}
