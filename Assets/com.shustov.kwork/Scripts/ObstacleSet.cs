using UnityEngine;

public class ObstacleSet : MonoBehaviour
{
    private Coins Coins { get; set; }

    private void Awake()
    {
        Coins = GetComponentInChildren<Coins>();
    }

    private void UpdateCoins() => Coins.SetCoin();
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
        UpdateCoins();
    }
}
