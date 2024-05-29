

public class PhysicsBug : Component
{
	public Rigidbody Rigidbody { get; set; }
	public BoxCollider BoxCollider { get; set; }

	protected override void OnAwake()
	{
		base.OnAwake();

		GameObject.Name = GetType().Name;

		Tags.Add( "solid" );

		Rigidbody ??= Components.GetOrCreate<Rigidbody>();

		BoxCollider ??= Components.GetOrCreate<BoxCollider>();


		/* */
		Log.Info( "OnAwake" );

		ToggleIsTrigger();

	}

	public async void ToggleIsTrigger()
	{
		// TODO Uncomment
		await GameTask.DelaySeconds( 1f );

		Log.Info( "ToggleIsTrigger with Delay" );

		BoxCollider.IsTrigger = true;
	}

	protected override void OnStart()
	{
		base.OnStart();

		var child = new GameObject();
		child.SetParent( GameObject, false );

		var baseModel = Model.Load( "models/citizen/citizen.vmdl" );

		var SkinnedModelRenderer = child.Components.GetOrCreate<SkinnedModelRenderer>();
		SkinnedModelRenderer.Model = baseModel;
		SkinnedModelRenderer.CreateBoneObjects = true;

		var ModelHitboxes = child.Components.GetOrCreate<ModelHitboxes>();
		ModelHitboxes.Renderer = SkinnedModelRenderer;
		ModelHitboxes.Target = GameObject;
	}

}
