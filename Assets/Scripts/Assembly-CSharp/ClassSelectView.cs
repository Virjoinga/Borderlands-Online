using A;
using Core;
using XsdSettings;

public class ClassSelectView : BaseView
{
	public delegate void ClassChangeEvent(AvatarType className);

	public ClassSelectBehaviour _logicBehaviour;

	protected ClassChangeEvent classChangeCB;

	protected ClassChangeEvent descChangeCB;

	public virtual void c578cb264f55b4d0af9261c41a382b885(ClassChangeEvent cb24ea666f3f25bc975f1e84effd63cad)
	{
		descChangeCB = cb24ea666f3f25bc975f1e84effd63cad;
	}

	public virtual void c8ce27f07ad125dcd5d8f638ce54309f8(ClassChangeEvent cb24ea666f3f25bc975f1e84effd63cad)
	{
		classChangeCB = cb24ea666f3f25bc975f1e84effd63cad;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		classChangeCB = null;
		descChangeCB = null;
	}

	public virtual void ce4bf9718485f72643b662cd66d5c4e8e(AvatarType cf5ba148a098c23b65a37f8a31abed165, string c682d9c5b8f0b6928c6d5849c0aaf023a, string c0ce45a37bb03b4f4f7562d4c32aaaac9, bool c35adbebab5b5b1c36c32e991f0208c00 = false)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "UI Base: Class Select setInfo: classID=";
		array[1] = cf5ba148a098c23b65a37f8a31abed165;
		array[2] = ", strTitle=";
		array[3] = c682d9c5b8f0b6928c6d5849c0aaf023a;
		array[4] = ", bFirstTime=";
		array[5] = c35adbebab5b5b1c36c32e991f0208c00;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
	}

	public virtual void cb061addc09fac4adf6f6700b27e998d9()
	{
	}

	public virtual void cc7fa43e9bd8fd461250ccf66a4c85f47(AvatarType cf5ba148a098c23b65a37f8a31abed165)
	{
	}

	protected void c236434cb1dd35d7dd3d7445ddba8a5a5(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "\n Password:" + c2b1dbe8e2d138df405faa6136d3c44c1);
	}

	protected void c8e60fb4f81068550dfc04c72900be46e()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onPrevClick ");
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.CharacterSelect, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	protected void cfc5920a5bb9bf351536e2ca4aea54e54()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onNextClick ");
		_logicBehaviour.c8397eef0dff99f09c31a8779aa646f1c();
	}
}
