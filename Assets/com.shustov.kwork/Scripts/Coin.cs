using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool IsEndPath { get; set; }
    public static Action OnDestinated { get; set; }
    private Transform Target { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("coinIcon").transform;
    }

    private void Update()
    {
        IsEndPath = (Vector2)Target.position == (Vector2)transform.position;
        if(IsEndPath)
        {
            OnDestinated?.Invoke();
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, Target.position, 20.0f * Time.deltaTime);
    }
}
