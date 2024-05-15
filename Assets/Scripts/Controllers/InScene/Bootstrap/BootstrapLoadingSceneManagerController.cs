
using System.Collections;
using System.ComponentModel;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLoadingSceneManagerController : SingletonPersistent<BootstrapLoadingSceneManagerController>
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(OnSceneLoadedCoroutine(scene));
    }

    private IEnumerator OnSceneLoadedCoroutine(Scene scene)
    {
        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeOut);
    }

    public void LoadScene(SceneName sceneToLoad, bool isNetworkSessionAction = false)
    {
        StartCoroutine(LoadSceneCoroutine(sceneToLoad, isNetworkSessionAction));
    }

    private IEnumerator LoadSceneCoroutine(SceneName sceneToLoad, bool isNetworkSessionActive = false)
    {
        BootstrapLoadingFadeEffectController.Instance.FadeIn();

        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeIn);

        if (isNetworkSessionActive)
        {
            LoadSceneNetwork(sceneToLoad);
        }
        else
        {
            LoadSceneLocal(sceneToLoad);
        }

        yield return new WaitForSeconds(1f);

        BootstrapLoadingFadeEffectController.Instance.FadeOut();

        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeOut);
    }

    private void LoadSceneLocal(SceneName sceneToLoad)
    {
        SceneManager.LoadScene(EnumUtility.GetDescription(sceneToLoad));
    }

    public void LoadSceneNetwork(SceneName sceneToLoad)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(
            EnumUtility.GetDescription(sceneToLoad),
            LoadSceneMode.Single);
    }
}

public enum SceneName
{
    [Description("Bootstrap")]
    Bootstrap,
    [Description("Title")]
    Title,
    [Description("Game")]
    Game
}
