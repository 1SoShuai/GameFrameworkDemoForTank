using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 坦克实体
    /// </summary>
    public class TankEntity : EntityLogic
    {
        [SerializeField]
        private TankData m_tankData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_tankData = userData as TankData;

            transform.position = m_tankData.Position;
        }
    }
}
