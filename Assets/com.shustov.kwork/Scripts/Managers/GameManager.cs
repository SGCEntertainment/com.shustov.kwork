using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get => FindObjectOfType<GameManager>();
    }

    private GameObject LevelRef { get; set; }

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

    private void Start()
    {
        game.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    public void StartGame()
    {
        result.SetActive(false);
        menu.SetActive(false);

        game.SetActive(true);

        LevelRef = Instantiate(Resources.Load<GameObject>("level"), GameObject.Find("Environment").transform);
    }

    public void Menu()
    {
        result.SetActive(false);
        game.SetActive(false);

        menu.SetActive(true);
    }

    public void GameOver()
    {
        SFXManager.Instance.PlayEffect(0);

        game.SetActive(false);
        result.SetActive(true);

        if(LevelRef)
        {
            Destroy(LevelRef);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
