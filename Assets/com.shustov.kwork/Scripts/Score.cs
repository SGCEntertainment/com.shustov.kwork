using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int count;
    private Text CountText { get; set; }

    private void OnEnable()
    {
        count = 0;
        CountText.text = $"{count}";
    }

    private void Awake()
    {
        CountText = GetComponent<Text>();
        Coin.OnDestinated += () =>
        {
            CountText.text = $"{++count}";
            SFXManager.Instance.PlayEffect(1);
        };
    }
}
