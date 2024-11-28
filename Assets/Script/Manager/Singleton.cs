using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance = null;

		public static bool IsAwake { get { return (_instance != null); } }

		/// <summary>
		/// gets the instance of this Singleton
		/// use this for all instance calls:
		/// MyClass.Instance.MyMethod();
		/// or make your public methods static
		/// and have them use Instance
		/// </summary>
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = (T)FindObjectOfType(typeof(T));
					if (_instance == null)
					{

						string goName = typeof(T).ToString();

						GameObject go = GameObject.Find(goName);
						if (go == null)
						{
							go = new GameObject();
							go.name = goName;
						}

						_instance = go.AddComponent<T>();
					}
				}
				return _instance;
			}
		}

		public virtual void OnApplicationQuit()
		{
			_instance = null;
		}

		protected void SetParent(string parentGOName)
		{
			if (parentGOName != null)
			{
				GameObject parentGO = GameObject.Find(parentGOName);
				if (parentGO == null)
				{
					parentGO = new GameObject();
					parentGO.name = parentGOName;
				}
				this.transform.parent = parentGO.transform;
			}
		}

	}
}
