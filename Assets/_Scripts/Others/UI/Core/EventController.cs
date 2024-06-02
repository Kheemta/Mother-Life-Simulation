using System.Collections.Generic;
using UnityEngine.Events;
namespace Mir
{
    public class EventController 
    {
        private Dictionary<string, DracoEvent> GameStateEvents;

		public EventController()
		{
			GameStateEvents = new Dictionary<string, DracoEvent>();

			Init();
		}
		~EventController()
		{
			//RemoveAll();
		}

		void Init()
        {
			InitGameEvents();
		}

        void InitGameEvents()
        {
			DracoArts.Instance.gameManager.GameStateEvents.ForEach(e =>
			{
				DracoEvent _event = new DracoEvent();
				GameStateEvents.Add(e,_event);
			});
			
        }

		public void Subscribe(EventType type,string eventName,UnityAction<string> action)
        {
            switch (type)
            {
				case EventType.GameStateEvent:
					GameStateEvents[eventName].AddListener(action);
				break;
            }
			
        }
		public void Trigger(EventType type,string eventName,string data)
        {
			switch (type)
			{
				case EventType.GameStateEvent:
					GameStateEvents[eventName].Invoke(data);
				break;
			}
		}
		public void UnSubscribe(EventType type, string eventName,UnityAction<string> action)
        {
			switch (type)
			{
				case EventType.GameStateEvent:
					GameStateEvents[eventName].RemoveListener(action);
				break;
			}
		}

	}

	[System.Serializable]
	public enum EventType
    {
		GameStateEvent
    };


	[System.Serializable]
	public class DracoEvent : UnityEvent<string>
	{
	}
}

