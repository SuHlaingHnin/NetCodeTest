using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{
    //private Lobby currentLobby;

    public override async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();

            SignInAnonymouslyAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");

        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };

        AuthenticationService.Instance.Expired += () =>
        {
            Debug.Log("Player session could not be refreshed and expired.");
        };
    }

    async void SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }

    }

    public async Task CreateLobby(string lobbyName, Action onSuccessCallback = null, Action onFailCallback = null)
    {
        //string lobbyName = "new lobby";
        int maxPlayers = 4;
        CreateLobbyOptions options = new CreateLobbyOptions();
        options.IsPrivate = false;

        try
        {
            await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

            NetworkManager.Singleton.StartHost();

            //Debug.Log("Created Lobby : " + currentLobby.Name);

            if (onSuccessCallback != null) onSuccessCallback();
        } 
        catch (LobbyServiceException e)
        {
            Debug.Log(e);

            if (onFailCallback != null) onFailCallback();
        }
    }

    public async Task JoinLobbyById(string lobbyId, Action onSuccessCallback = null, Action onFailCallback = null)
    {
        try
        {
            await LobbyService.Instance.JoinLobbyByIdAsync(lobbyId);

            NetworkManager.Singleton.StartClient();

            if (onSuccessCallback != null) onSuccessCallback();
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);

            if(onFailCallback != null) onFailCallback();
        }
    }

    public async Task<List<Lobby>> GetLobbies()
    {
        try
        {
            QueryLobbiesOptions options = new QueryLobbiesOptions();
            options.Count = 25;

            // Filter for open lobbies only
            options.Filters = new List<QueryFilter>()
            {
                new QueryFilter(
                    field: QueryFilter.FieldOptions.AvailableSlots,
                    op: QueryFilter.OpOptions.GT,
                    value: "0")
            };

            // Order by newest lobbies first
            options.Order = new List<QueryOrder>()
            {
                new QueryOrder(
                    asc: false,
                    field: QueryOrder.FieldOptions.Created)
            };

            QueryResponse response = await Lobbies.Instance.QueryLobbiesAsync(options);

            return response.Results;

            //if (onSuccessCallback != null) onSuccessCallback(response.Results);

            //List<Lobby> lobbiesList = response.Results;

            //foreach (Lobby lobby in lobbiesList)
            //{
            //    Debug.Log(lobby.Name);
            //}
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
        return null;
    }
}
