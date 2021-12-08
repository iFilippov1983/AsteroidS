using System.Collections;
using UnityEngine;

namespace AsteroidS
{
	internal sealed class CoroutinesController : MonoBehaviour
	{
		private static CoroutinesController _coroutine;

		private static CoroutinesController Instance
		{
			get
			{
				if(_coroutine == null)
				{
					var go = new GameObject("[COROUTINE MANAGER]");
					_coroutine = go.AddComponent<CoroutinesController>();
					
					DontDestroyOnLoad(go);
				}
				return _coroutine;
			}
		}
		
		public static Coroutine StartRoutine (IEnumerator enumerator)
		{
			return Instance.StartCoroutine(enumerator);
		}

		public static void StopRoutine (Coroutine coroutine)
		{
			Instance.StopCoroutine(coroutine);
		}

        private void OnDestroy()
        {
			StopAllCoroutines();
        }
    }
}
