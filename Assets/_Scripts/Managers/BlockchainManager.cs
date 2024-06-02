// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Nethereum.Signer;
// using UnityEngine.Events;
// using System;

// using Nethereum.Signer;
// using Nethereum.Hex.HexConvertors.Extensions;
// using Nethereum.ABI.Encoders;

// using NBitcoin;

// using Nethereum.HdWallet;


// namespace Mir
// {
//     namespace Core
//     {
//         public class BlockchainManager : MonoBehaviour
//         {
            
//             public  void Awake()
//             {
//                 // Init TorusDirect
//             }
           
            
//             private void OnEnable()
//             {
            
//             }

//             public void CreateInGameWallet(UnityAction<BlockChainKeys> action)
//             {
//                 BlockChainKeys keys;
//                 try
//                 {
//                     EthECKey ecKey = EthECKey.GenerateKey();
 
//                     string privateKey = ecKey.GetPrivateKey();
//                     string publicKey = ecKey.GetPublicAddress();
//                     keys = new BlockChainKeys(publicKey, privateKey);
//                 }
//                 catch(Exception e)
//                 {
//                     keys = new BlockChainKeys();
//                 }
//                 action(keys);
//             }




//             public string GenerateRandomMnemonic()
//             {
               
//                 Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
          
//                 return mnemonic.ToString();
//             }

//             // Custom abdullah


//             public void CreateHDWallet( string mnemonic , string password = "", UnityAction<BlockChainKeys> action = null)
//             {
//                 BlockChainKeys keys;
                
//                 try { 
//                     var wallet = new Wallet(mnemonic, password);

//                     EthECKey ecKey = wallet.GetEthereumKey(0);

//                       string privateKey =  ecKey.GetPrivateKey();
//                       string publicKey = ecKey.GetPublicAddress();
//                       keys = new BlockChainKeys(publicKey, privateKey);
//                 }
//                 catch(Exception e)
//                 {
//                     keys = new BlockChainKeys();
                   
//                 }

//                 if(action!=null)
//                     action(keys);
//             }


//             public void RecoverAccount( string mnemonic, string password = "" , UnityAction<BlockChainKeys> action = null )
//             {
           
//                 BlockChainKeys keys;
//                 try { 
//                 var wallet = new Wallet(mnemonic, password);
//                 EthECKey ecKey = wallet.GetEthereumKey(0);

//                 string privateKey = ecKey.GetPrivateKey();
//                 string publicKey = ecKey.GetPublicAddress();

//                  keys = new BlockChainKeys(publicKey , privateKey);

              
//                 }


//                 catch(Exception e)
//                 {
//                     keys = new BlockChainKeys();
//                 }

//                 if (action != null)
//                     action(keys);
              
//             }



//             public void GetEtheriumBalance(string privateKey)
//             {

//             }


//             public string SignMessage(string message , string privateKey)
//             {
//                 var signer = new EthereumMessageSigner();
//                 return signer.EncodeUTF8AndSign(message, new EthECKey(privateKey));
//             }


//         }

//         [System.Serializable]
//         public class BlockChainKeys
//         {
//             public string publicKey;
//             public string privateKey;

//             public BlockChainKeys()
//             {
//                 this.publicKey = "0x0";
//                 this.privateKey = "0x0";
//             }
//             public BlockChainKeys(string publicKey,string privateKey)
//             {
//                 this.publicKey = publicKey; 
//                 this.privateKey = privateKey;
//             }
//         }
//     }

// }
