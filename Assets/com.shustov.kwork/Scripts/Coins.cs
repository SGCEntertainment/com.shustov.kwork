using UnityEngine;

public class Coins : MonoBehaviour
{
    public void SetCoin()
    {
        int coinIndex = Random.Range(0, transform.childCount);
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(t.GetSiblingIndex() == coinIndex);
        }
    }
}
