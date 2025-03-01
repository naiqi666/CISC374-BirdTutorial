  using UnityEngine;
  using UnityEngine.SceneManagement;

  public class MainMenuController : MonoBehaviour
  {
      public void StartGame()
      {
          SceneManager.LoadScene("Bird"); // Replace "GameScene" with the name of your gameplay scene
      }
  }

