using System.Collections;
using System.Collections.Generic;
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
					var go = new GameObject("[COROUTINES CONTROLLER]");
					_coroutine = go.AddComponent<CoroutinesController>();
					
					DontDestroyOnLoad(go);
				}
				return _coroutine;
			}
		}

		public static void StartAllRoutines(Stack<IEnumerator> routines)
		{
			foreach (var routine in routines) StartRoutine(routine);
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
