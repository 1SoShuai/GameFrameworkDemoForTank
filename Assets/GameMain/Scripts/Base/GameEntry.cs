using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Tank
{
	/// <summary>
	/// 游戏入口
	/// </summary>
	public partial class GameEntry : MonoBehaviour
	{
        private void Start()
		{
			InitBuiltinComponents();
			InitCustomComponents();
		}
	}
}
