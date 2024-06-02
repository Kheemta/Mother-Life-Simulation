using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mir
{
    namespace Body
    {
        [System.Serializable]
        public class LoginWallet_Body
        {
            public string publicAddress;
            public string signature;

            public LoginWallet_Body(string publicAddress,string signature)
            {
                this.publicAddress = publicAddress;
                this.signature = signature;
            }
        }
        [System.Serializable]
        public class UpdateProfile_Body
        {
            public string name;
            public string phone;
            public string email;

            public UpdateProfile_Body(string name,string phone,string email)
            {
                this.name = name;
                this.email = email;
                this.phone = phone;
            }
        }

        
    }
}

