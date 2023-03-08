using UnityEngine;

public class Level : MonoBehaviour
{
    private const float yOffset = 1.98f;
    private const float xlimit = -13.0f;

    private const float offset = 20.0f;
    private const float space = 10.0f;

    private const float speed = 3.0f;
    private ObstacleSet[] ObstacleSets { get; set; }

    private void Start()
    {
        var obstacles = GameObject.Find("obstacles").transform;
        ObstacleSets = new ObstacleSet[obstacles.childCount];

        for (int i = 0; i < ObstacleSets.Length; i++)
        {
            ObstacleSets[i] = obstacles.GetChild(i).GetComponent<ObstacleSet>();

            float x = offset + i * space;
            float y = Random.Range(-yOffset, yOffset);

            ObstacleSets[i].SetPosition(new Vector2(x, y));
        }
    }

    private void Update()
    {
        foreach(ObstacleSet t in ObstacleSets)
        {
            t.transform.Translate(speed * Time.deltaTime * Vector2.left);
            if(t.transform.position.x < xlimit)
            {
                float x = GetLastX(t.transform) + space;
                float y = Random.Range(-yOffset, yOffset);

                t.SetPosition(new Vector2(x, y));
                t.transform.SetAsLastSibling();
            }
        }
    }

    private float GetLastX(Transform t)
    {
        return t.parent.GetChild(t.parent.childCount - 1).position.x;
    }
}
