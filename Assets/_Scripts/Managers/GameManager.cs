using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mir
{
    namespace Core
    {
        public class GameManager : MonoBehaviour
        {
            private EventController _events;
            private void OnEnable()
            {
                _events = new EventController();
            }
            private void OnDisable()
            {

            }
            #region Game Events
            public List<string> GameStateEvents;
            

            public void Subscribe(EventType type, string eventName, UnityAction<string> action)
            {
                _events.Subscribe(type, eventName, action);
            }
            public void UnSubscribe(EventType type, string eventName, UnityAction<string> action)
            {
                _events.UnSubscribe(type, eventName, action);
            }
            public void Trigger(EventType type, string eventName, string data = "")
            {
                _events.Trigger(type, eventName, data);
            }
            #endregion

        }
    }
}
