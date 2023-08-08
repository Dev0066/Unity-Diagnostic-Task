using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RequestController : MonoBehaviour
{
    [SerializeField] private string url;
    [SerializeField] private Button tryAgain;
    [SerializeField] private UiController uiController;
    private Coroutine currentCoroutine;

    private void Awake()
    {
        GetAnimalsData();
    }

    public void GetAnimalsData()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(GettingAnimalsData());
    }

    IEnumerator GettingAnimalsData()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log("Something gona wrong, please check your interent connection and try again");
            tryAgain.onClick.AddListener(() =>
            {
                GetAnimalsData();
                tryAgain.gameObject.SetActive(false);
            });
            tryAgain.gameObject.SetActive(true);
        }
        else
        {
            AnimalsData animalsData = JsonUtility.FromJson<AnimalsData>("{\"Animals\":"+webRequest.downloadHandler.text+"}");
            uiController.CreateAnimalsCards(animalsData);
        }

        currentCoroutine = null;
    }
}
