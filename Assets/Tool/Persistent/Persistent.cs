using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;    


    public class Persistent : MonoBehaviour
    {
        const string persistentKey = "Persistent";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void PersistentInsitate()
        {
            Addressables.InstantiateAsync(persistentKey).Completed += operationHandle =>
            {
                DontDestroyOnLoad(operationHandle.Result);
            };


        }
    }

