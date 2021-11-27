using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingCallBack : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
}
