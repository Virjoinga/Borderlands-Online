using UnityEngine;
using pumpkin.display;

namespace pumpkin.displayInternal
{
	public interface IGraphicsGenerator
	{
		MeshGeneratorOptions meshGeneratorOptions { get; set; }

		bool renderStage(Stage stage);

		Mesh applyToMeshRenderer(MeshRenderer meshRenderer);

		void drawMeshNow(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale);

		SimpleStageRenderResult getSimpleStageRenderResult();
	}
}
