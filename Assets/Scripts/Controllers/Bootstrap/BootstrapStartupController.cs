using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapStartupController : SingletonPersistent<BootstrapStartupController>
{
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => 
        BootstrapLoadingSceneManagerController.Instance != null
        && BootstrapLoadingFadeEffectController.Instance != null
        && BootstrapModalController.Instance != null 
        );

        BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Title);
    }

}
