using UnityEngine.UI;

namespace MakeTen.Presentation.View.Common
{
    public class ClickDetector : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            // Base クラスで Mesh を生成しているので、override で Mesh を生成させないようにする。
            // Graphic はデフォルトで DoLegacyMeshGeneration() を呼ぶようになっており、
            // その中で OnPopulateMesh(Graphic.workerMesh) を実行している。
            // Graphic.workerMesh (= vh) にアクセスしてしまうと、Mesh が自動生成されるようになっている

            // Mesh が生成されると、Sprite が貼られていない Image のように、白い画像が出力されるのでどうにかしないといけない。
            // vh で mesh が必ず作られてしまうので、Clear を叩いて Mesh を削除する。
            vh.Clear();
        }
    }
}