
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _gameEndText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private GameObject _button;
    [SerializeField] private MazeGenerator _mazeGenerator;
    public TMP_Text GameEndText() { return _gameEndText; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EconomyManager.OnMoneyChanged += SetCoinText;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
    public void WinUI()
    {
        _gameEndText.text = "Congratulations";
        _buttonText.text = "Next Level";
        _button.transform.DOScale(1f, .5f);
    }
    public void LoseUI()
    {
        _gameEndText.text = "Game Over";
        _buttonText.text = "Try Again";
        _button.transform.DOScale(1f, .5f);
    }

    private void OnDisable()
    {
        EconomyManager.OnMoneyChanged -= SetCoinText;
    }

    private void SetCoinText(int coinAmount)
    {
        _coinText.text = "Coin:"+ $"{coinAmount}";
    }

}
