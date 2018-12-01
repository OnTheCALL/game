using UnityEngine;

[System.Serializable]
public class DiscordJoinEvent : UnityEngine.Events.UnityEvent<string> { }

[System.Serializable]
public class DiscordSpectateEvent : UnityEngine.Events.UnityEvent<string> { }

[System.Serializable]
public class DiscordJoinRequestEvent : UnityEngine.Events.UnityEvent<discordRPC.DiscordUser> { }

public class discordController : MonoBehaviour
{
	public discordRPC.RichPresence presence = new discordRPC.RichPresence();
	public string applicationId;
	public string optionalSteamId;
	public int clickCounter;
	public discordRPC.DiscordUser joinRequest;
	public UnityEngine.Events.UnityEvent onConnect;
	public UnityEngine.Events.UnityEvent onDisconnect;
	public UnityEngine.Events.UnityEvent hasResponded;
	public DiscordJoinEvent onJoin;
	public DiscordJoinEvent onSpectate;
	public DiscordJoinRequestEvent onJoinRequest;

	public string Grade = "Sapeur";
	float nextUpdate = -100.0f;

	discordRPC.EventHandlers handlers;

	public void Update_discord()
	{
		presence.largeImageKey = "white1";
		presence.state = "en astreinte";
		presence.details = Grade;
		presence.largeImageText = "Simulateur de pompier ( https://discord.gg/u5GrRKu )";

		discordRPC.UpdatePresence(presence);
	}

	public void RequestRespondYes()
	{
		Debug.Log("Discord: responding yes to Ask to Join request");
		discordRPC.Respond(joinRequest.userId, discordRPC.Reply.Yes);
		hasResponded.Invoke();
	}

	public void RequestRespondNo()
	{
		Debug.Log("Discord: responding no to Ask to Join request");
		discordRPC.Respond(joinRequest.userId, discordRPC.Reply.No);
		hasResponded.Invoke();
	}

	public void ReadyCallback(ref discordRPC.DiscordUser connectedUser)
	{
		Debug.Log(string.Format("Discord: connected to {0}#{1}: {2}", connectedUser.username, connectedUser.discriminator, connectedUser.userId));
		onConnect.Invoke();
		nextUpdate = 0.0f;
	}

	public void DisconnectedCallback(int errorCode, string message)
	{
		Debug.Log(string.Format("Discord: disconnect {0}: {1}", errorCode, message));
		onDisconnect.Invoke();
	}

	public void ErrorCallback(int errorCode, string message)
	{
		Debug.Log(string.Format("Discord: error {0}: {1}", errorCode, message));
	}

	public void JoinCallback(string secret)
	{
		Debug.Log(string.Format("Discord: join ({0})", secret));
		onJoin.Invoke(secret);
	}

	public void SpectateCallback(string secret)
	{
		Debug.Log(string.Format("Discord: spectate ({0})", secret));
		onSpectate.Invoke(secret);
	}

	public void RequestCallback(ref discordRPC.DiscordUser request)
	{
		Debug.Log(string.Format("Discord: join request {0}#{1}: {2}", request.username, request.discriminator, request.userId));
		joinRequest = request;
		onJoinRequest.Invoke(request);
	}

	void Start()
	{
	}

	void Update()
	{
		discordRPC.RunCallbacks();
		nextUpdate = nextUpdate - Time.deltaTime;
		if (nextUpdate <= 0.0f && nextUpdate > -100.0f) {
			nextUpdate = nextUpdate + 10.0f;
			Update_discord ();
		}
	}

	void OnEnable()
	{
		Debug.Log("Discord: init");
		handlers = new discordRPC.EventHandlers();
		handlers.readyCallback += ReadyCallback;
		handlers.disconnectedCallback += DisconnectedCallback;
		handlers.errorCallback += ErrorCallback;
		handlers.joinCallback += JoinCallback;
		handlers.spectateCallback += SpectateCallback;
		handlers.requestCallback += RequestCallback;
		discordRPC.Initialize(applicationId, ref handlers, true, optionalSteamId);
	}

	void OnDisable()
	{
		Debug.Log("Discord: shutdown");
		discordRPC.Shutdown();
	}

	void OnDestroy()
	{

	}
}
