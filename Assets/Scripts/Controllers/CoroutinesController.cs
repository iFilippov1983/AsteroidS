using System.Collections;
using UnityEngine;

namespace AsteroidS
{
	internal sealed class CoroutinesController : MonoBehaviour
	{
		private static CoroutinesController _coroutine;

		private static CoroutinesController instance
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
			return instance.StartCoroutine(enumerator);
		}

		public static void StopRoutine (Coroutine coroutine)
		{
			instance.StopCoroutine(coroutine);
		}

        private void OnDestroy()
        {
			StopAllCoroutines();
        }
    }
}
