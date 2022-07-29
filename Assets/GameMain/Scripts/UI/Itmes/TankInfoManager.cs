using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tank
{
    /// <summary>
    /// 坦克信息控制类
    /// </summary>
    public class TankInfoManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text attack, defense, speed;

        [SerializeField]
        private Slider attack_slider, defense_slider, speed_slider;

        Dictionary<int, TankInfo> tankDic = new Dictionary<int, TankInfo>();

        private void Awake()
        {
            IDataTable<DRTankInfo> tanks = GameEntry.DataTable.GetDataTable<DRTankInfo>();

            foreach (var tank in tanks)
            {
                TankInfo info = new TankInfo();
                info.Attack = tank.Attack;
                info.Defense = tank.Defense;
                info.Speed = tank.Speed;

                tankDic.Add(tank.Id, info);
            }
        }

        /// <summary>
        /// 设置坦克展示信息
        /// </summary>
        /// <param name="tankId"></param>
        public void SetTankInfo(int tankId)
        {
            TankInfo info = tankDic[tankId];
            attack.text = info.Attack.ToString();
            defense.text = info.Defense.ToString();
            speed.text = info.Speed.ToString();

            attack_slider.value = info.Attack;
            defense_slider.value = info.Defense;
            speed_slider.value = info.Speed;
        }
    }

    public struct TankInfo
    {
        public int Attack;
        public int Defense;
        public int Speed;
    }
}
