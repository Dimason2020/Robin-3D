using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : Singleton<UIHandler>
{
    [SerializeField] private Button loseButton, winButton;

    [SerializeField]
    private GameObject winWindow,
        loseWindow;

    public override void Awake()
    {
        base.Awake();

        winButton.onClick.AddListener(ReloadScene);
        loseButton.onClick.AddListener(ReloadScene);
    }

    private void OnEnable()
    {
        EnemyHandler.Instance.OnAllEnemyDead += () =>
        {
            winWindow.SetActive(true);
        };

        Player.Instance.OnPlayerDead += () =>
        {
            loseWindow.SetActive(true);
        };
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
