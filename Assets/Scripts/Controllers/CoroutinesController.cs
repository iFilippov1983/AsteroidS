using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
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
	}
}
