using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneRestart : MonoBehaviour
{
    
    [SerializeField]
    private SceneRestartAnimation _sceneRestartAnimation;
    
    

    public void ActivateRestartInterface()
    {
        _sceneRestartAnimation.Activate();
    }

    public void RestartScene()
    {
        _sceneRestartAnimation.AnimateFade().OnComplete((() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex)));
    }
    
    private void Start()
    {
        _sceneRestartAnimation.Deactivate();
    }
}
