using UnityEngine;

public class Buildings : MonoBehaviour
{
    private const float speed = 0.5f;
    private void LateUpdate()
    {
        foreach(Transform t in transform)
        {
            t.Translate(speed * Time.deltaTime * Vector2.left);
            if(t.position.x <= -23.9f)
            {
                float x = transform.GetChild(transform.childCount - 1).position.x + 22.81f;
                t.position = new Vector2(x, t.position.y);

                t.SetAsLastSibling();
            }
        }
    }
}
