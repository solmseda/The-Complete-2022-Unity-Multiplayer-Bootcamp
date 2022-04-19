using System.Collections.Generic;
using PlayerIOClient;
using UnityEngine;

namespace Project.Network
{
    public class NetworkClient
    {
        private static NetworkClient mInstance;
        private static string _gameID = "unitymultplayerbootcamp-ecv6s3qqe6orfup45g7w";

        public static NetworkClient GetInstance()
        {
            return mInstance ??= new NetworkClient();
        }

        public static void RegisterUser(string username, string password)
        {
            PlayerIO.Authenticate(_gameID, "public", new Dictionary<string, string>
                {
                    {"register", "true"},
                    {"username", username},
                    {"password", password}
                }, null, delegate(Client client) { Debug.Log("Registration Successfully"); },
                delegate(PlayerIOError error) { Debug.Log($"Registration Failed: {error.Message}"); });
        }
        public static void LoginUser(string username, string password)
        {
            PlayerIO.Authenticate(_gameID, "public", new Dictionary<string, string>
                {
                    {"username", username},
                    {"password", password}
                }, null, delegate(Client client)
                {
                    Debug.Log("Login Successfully");
                    GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>()
                        .OnAuthenticationComplete();
                },
                delegate(PlayerIOError error) { Debug.Log($"Login Failed: {error.Message}"); });
        }
    }
}