using System.Collections;
using UnityEngine;


public static class CoroutineStarter
{
    private static readonly MonoBehaviour coroutineStarter;
    public static Coroutine StartCoroutine(IEnumerator function)
    {
        return coroutineStarter.StartCoroutine(function);
    }

    public static void StopCoroutine(IEnumerator function)
    {
        if (function != null)
        {
            coroutineStarter.StopCoroutine(function);
        }
    }

    static CoroutineStarter()
    {
        coroutineStarter = new GameObject("CoroutineStarter").AddComponent<MonoBehaviour>();
        Object.DontDestroyOnLoad(coroutineStarter.gameObject);
    }

    public static void DelayedExecution(float delay, System.Action function)
    {
        StartCoroutine(DelayedExecuteCoroutine(delay, function));
    }

    static IEnumerator DelayedExecuteCoroutine(float delay, System.Action function)
    {
        yield return new WaitForSeconds(delay);
        function();
    }
}