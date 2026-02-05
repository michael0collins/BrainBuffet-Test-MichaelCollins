using DG.Tweening;
using UnityEngine;

public class GameStatePaused : GameState
{
    [SerializeField] GameObject _pausePanel;

    public void Unpause()
    {
        GameManager.Instance.ChangeGameState("Gameplay");
    }

    public override void OnStateBegin()
    {
        base.OnStateBegin();

        Time.timeScale = 0;

        _pausePanel.gameObject.SetActive(true);
    }

    public override void OnStateEnd()
    {
        base.OnStateEnd();

        Time.timeScale = 1;

        _pausePanel.gameObject.SetActive(false);
    }
}