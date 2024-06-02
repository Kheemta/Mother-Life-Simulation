namespace Mir
{ 
    namespace Responses
    {
        [System.Serializable]
        public class Create_Sessions
        {
            public int code;
            public string objectId;
            public string username;
            public string phone;
            public string email;
            public string installationId;
            public string error;
        }
        [System.Serializable]
        public class Retriving_Session
        {
            public int code;
            public string error;
        }
        [System.Serializable]
        public class Update_Session
        {
            public int code;
            public string error;
        }
        [System.Serializable]
        public class Delete_Session
        {
            public int code;
            public string error;
        }
    }

}
   

