namespace Sandbox;

public sealed class PlayerSpawnerManager : Component
{
	protected override void OnStart()
	{
		Log.Info( "PlayerSpawnerManager" );

		var player = new GameObject();
		player.Parent = Game.ActiveScene;
		player.Components.Create<NetworkTest>();

		player.Tags.Add( "player" );

		var body = new GameObject();
		body.Name = "Body";
		body.Parent = player;

		var bodySkinnedModelRenderer = body.Components.Create<SkinnedModelRenderer>();
		bodySkinnedModelRenderer.Model = Model.Load( "models/citizen/citizen.vmdl" );
		bodySkinnedModelRenderer.RenderType = ModelRenderer.ShadowRenderType.ShadowsOnly;
		bodySkinnedModelRenderer.CreateBoneObjects = true;

		var eyes = new GameObject();
		eyes.Name = "Eyes";
		eyes.Transform.LocalPosition = new Vector3( 0, 0, 64f );
		eyes.SetParent( player );

		var characterController = player.Components.Create<CharacterController>();
		characterController.UseCollisionRules = true;
		var playerController = player.Components.Create<PlayerController>();
		playerController.Body = body;
		playerController.Eye = eyes;

		/* */

		var goPhysicBug = new GameObject();
		goPhysicBug.Transform.Position = Vector3.Up * 256f;
		goPhysicBug.Components.Create<PhysicsBug>();
		goPhysicBug.Name = "PhysicBugCode";
	}
}
