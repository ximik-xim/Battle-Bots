using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] 
    private int _IdScene;

    [SerializeField] 
    private float _time;
    private CancellationTokenSource _token = new CancellationTokenSource();

    public void Transition()
    {
        SceneManager.LoadScene(1);
        Timer(LoadingScen, _token.Token);
    }

    private void LoadingScen()
    {
        SceneManager.LoadScene(_IdScene);
    }

    private async Task Timer(Action action, CancellationToken token)
    {
        await Task.Delay((int) (_time * 1000),token);
        action?.Invoke();
        action = null;
    }
}
