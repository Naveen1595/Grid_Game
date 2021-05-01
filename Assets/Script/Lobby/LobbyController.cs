using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]private Button startButton;
    [SerializeField]private Button ExitButton;

    private void Update()
    {
        startButton.onClick.AddListener(StartTheGame);
        ExitButton.onClick.AddListener(ExitTheGame);
    }

    void StartTheGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void ExitTheGame()
    {
        Application.Quit();
    }

}
