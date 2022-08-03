using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using GameFramework.Event;

namespace Tank
{
    /// <summary>
    /// 双人匹配场景
    /// </summary>
    public class TwoPlayerMatchingForm : UIFormLogic
    {
        [SerializeField]
        private TMP_Text timer, hits;

        [SerializeField]
        private Button btn_exit;

        ProcedureMatching matching;

        private int timeCount;
        private bool keepTimer;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            matching = userData as ProcedureMatching;

            btn_exit.onClick.AddListener(OnExitClick);
            GameEntry.Event.Subscribe(PlayerEnterRoomEventArgs.EventId, OnPlayerEnterRoom);

            timeCount = 0;
            keepTimer = true;
            StartCoroutine(TimerEnum());
        }

        private WaitForSeconds wait = new WaitForSeconds(1);
        
        IEnumerator TimerEnum()
        {
            while (keepTimer)
            {
                timer.text = timeCount++.ToString();
                yield return wait;
            }
            
        }

        private void OnPlayerEnterRoom(object sender, GameEventArgs e)
        {
            PlayerEnterRoomEventArgs args = (PlayerEnterRoomEventArgs)e;

            hits.text = args.playerName + " enter room...";
        }

        private void OnExitClick()
        {
            matching.ChangeToLobby();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            btn_exit.onClick.RemoveListener(OnExitClick);
            GameEntry.Event.Unsubscribe(PlayerEnterRoomEventArgs.EventId, OnPlayerEnterRoom);

            keepTimer = false;
        }
    }
}
