using UnityEngine;

public class Viewer : MonoBehaviour
{
    private UniWebView View { get; set; }

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        Manager.OnGetResponseFinished += OnGetResponseHandler;
    }

    private void OnDestroy()
    {
        Manager.OnGetResponseFinished -= OnGetResponseHandler;
    }

    private void OnGetResponseHandler(string url)
    {
        Destroy(GameObject.Find("spinner"));
        View.Load(url);
    }

    void CacheComponents()
	{
        View = gameObject.AddComponent<UniWebView>();
        Camera.main.backgroundColor = Color.black;

        View.ReferenceRectTransform  = GameObject.Find("rect").GetComponent<RectTransform>();

        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        View.ReferenceRectTransform.anchorMin = anchorMin;
        View.ReferenceRectTransform.anchorMax = anchorMax;

        View.SetShowSpinnerWhileLoading(false);
        View.BackgroundColor = Color.white;

        View.OnOrientationChanged += (v, o) =>
        {
			Screen.fullScreen = o == ScreenOrientation.Landscape;

            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            v.ReferenceRectTransform.anchorMin = anchorMin;
            v.ReferenceRectTransform.anchorMax = anchorMax;

            View.UpdateFrame();
        };

        View.OnShouldClose += (v) =>
        {
            return false;
        };

        View.OnPageStarted += (browser, url) =>
        {
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            View.ReferenceRectTransform.anchorMin = anchorMin;
            View.ReferenceRectTransform.anchorMax = anchorMax;

            View.Show();
            View.UpdateFrame();
        };

        View.OnPageFinished += (browser, code, url) =>
        {
            
        };
    }
}
