using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 坦克数据类 
    /// </summary>
    [Serializable]
    public class TankData : EntityData
    {
        public TankData(int entityId, int typeId) : base(entityId, typeId)
        {
            Position = new UnityEngine.Vector3(0, -1.3f, 0.5f);
        }

    }
}
