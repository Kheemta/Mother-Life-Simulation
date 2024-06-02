using System.Collections;
using System.Collections.Generic;

namespace Mir
{
    namespace Responses
    {
        [System.Serializable]
        public class User_Null_Response { }

        [System.Serializable]
        public class Login_Response
        {
            public int code;
            public string objectId;
            public string username;
            public string phone;
            public string email;
            public string error;
            public string sessionToken;
        }

        [System.Serializable]
        public class SignUp_Response
        {

            public int code;
            public string objectId;
            public string username;
            public string phone;
            public string email;
            public string error;
            public string sessionToken;

        }

        [System.Serializable]
        public class Verfying_Email
        {
            public int code;
            public string error;
        }

        [System.Serializable]
        public class Request_PasswordReset
        {
            public int code;
            public string error;
            public string objectId;
            public string sessionToken;
        }

        [System.Serializable]
        public class Nonce_Response
        {
            public string role;
            public string nonce;
            public string id;
        }

        [System.Serializable]
        public class LoginwithWallet_Response
        {
            public string token;
        }

        [System.Serializable]
        public class UpdateProfile_Response
        {
            public string email;
            public string uName;
            public string phone;
        }

        [System.Serializable]
        public class GetSingleUser_Response
        {
            public string email;
            public string uName;
        }
        [System.Serializable]
        public class SingleQuest_Response
        {
            public string currency;
            public string fee;
            public string sceneName;
            public string desc;
            public long startTime;
            public long endTime;
            public string image; // image
            public string userId;
            public string updatedAt;
            public string id; // Quest ID
            public string minAmount;
            public string title;
        }
        [System.Serializable]
        public class GetAllQuests_Response
        {
            public List<SingleQuest_Response> Items;
        }
    }
}

