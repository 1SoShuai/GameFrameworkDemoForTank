using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 
    /// </summary>
    public class TankLogic : EntityLogic
    {
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            TankData data = userData as TankData;

            transform.position = data.Position;
        }
    }
}
