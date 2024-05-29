
public sealed class NetworkTest : Component
{
	[Property] public CameraComponent Camera { get; set; }

	protected override void OnStart()
	{
		base.OnStart();

		Camera = Game.ActiveScene.GetAllComponents<CameraComponent>().FirstOrDefault();

	}

}
