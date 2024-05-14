# BeatTogether.UnifiedServer
A multiplayer private server for the modding community. Supports crossplay between PC and Quest.

## Note
If you are looking to just play BeatTogether you can download it for your respective platform at the links below. This repository is for contribution to the server that runs the matchmaking services.

PC: [here](https://github.com/pythonology/BeatTogether#installation).

Quest: [here](https://github.com/pythonology/BeatTogether.Quest#installation).

## Feeling adventurous? Want to host your own server?

### All in one server

Head to the releases tab and download etc etc

Setting up the config: 
This example config works for hosting your own local server instance.

`appsettings.json`
```
{
  "Urls": "http://0.0.0.0:8989", //ip that gamelift listens on, and that the status api uses
  "Serilog": {
    "File": {
      "Path": "logs/BeatTogether.MasterServer-{Date}.log" //log file name
    },
    "MinimumLevel": { //Logging levels
      "Default": "Information",
      "Overrides": {
        "Microsoft": "Warning"
      }
    }
  },
  "Status": { //Status api configuration
    "MinimumAppVersion": "1.35.0",             // Minumum game version to join
    "ServerDisplayName": "BeatTogether server",// The name of your server
    "ServerDescription": "",                   // The description of your server
    "ServerImageUrl": "",                      // The icon displayed for your server
    "MaxPlayers": 30,                          // Max players that can join a lobby in your server (Not used yet but planned)
    "UseSsl": false,                           // Whether this server uses Ssl
    "ServerSupportsPPModifiers": true,         // Whether your server supports the ability for players to select seperate gameplay modifiers
    "ServerSupportsPPDifficulties": true,      // Whether your server supports the ability for players to select their own difficulties in gameplay
    "ServerSupportsPPMaps": false              // Whether your server supports the ability for players to play different beatmaps at the same time (Currently not used)
    "RequiredMods": [                          // minimum required mod versions, if installed. Used when we know there is a mod that causes issues with multiplayer, and informs the client to use a newer version of that mod to prevent game crashes
      {
        "id": "MultiplayerCore",
        "version": "1.2.0"
      },
      {
        "id": "BeatTogether",
        "version": "2.0.1"
      },
      {
        "id": "BeatSaberPlus_SongOverlay",
        "version": "4.6.1"
      },
      {
        "id": "EditorEX",
        "version": "1.2.0"
      },
      {
        "id": "LeaderboardCore",
        "version": "1.2.2"
      }
    ]
  },
  "Quickplay": {
    "PredefinedPacks": [                       // What level packs can appear in quickplay
      {
        "order": 0,
        "packId": "ALL_LEVEL_PACKS"
      },
      {
        "order": 1,
        "packId": "BUILT_IN_LEVEL_PACKS"
      }
    ],
    "LocalizedCustomPacks": [
      {
        "serializedName": "customlevels",      // Adds custom levels pack option to quickplay
        "order": 2,
        "localizedNames": [
          {
            "language": "English",
            "packName": "Custom"
          }
        ],
        "packIds": [
          "custom_levelpack_CustomLevels"
        ]
      }
    ]
  },
  "ServerConfiguration": {
    "HostEndpoint": "127.0.0.1",     // The endpoint that is used to host lobbies
    "AuthenticateClients": true      // Whether clients should be authenticated
    "BasePort": 30000,               // The ports for individual lobbies start here
    "MaximumSlots": 10000            // Max number of lobbies
  }
}
```
Notes:
If not hosting locally then,
You will need to set `HostEndpoint` to your public facing ip address.
You will need to port forward the port `8989` (The port in the api url) and all the ports between `BasePort` and `BasePort` + `MaximumSlots`.

#### BeatTogether Mod Configuration
If not local, then set every occurance of `127.0.0.1` in the config below, to the `HostEndpoint` from the configuration above

`BeatTogether.json` in `BeatSaber/Userdata/`
```
{
  ...
  "Servers": [
    ...
    {
      "ServerName": "Local",
      "HostName": "127.0.0.1",
      "ApiUrl": "http://127.0.0.1:8989",
      "StatusUri": "http://127.0.0.1:8989/status",
      "MaxPartySize": 30,
    },
    ...
  ]
  ...
}

```



### Master-Dedi node based system for scalability

We haven't written a official version of server hosting yet, but here is a guide from a fellow community member!

Guide: [here](https://github.com/qe201020335/BeatTogether-DockerCompose#how-to-host).
