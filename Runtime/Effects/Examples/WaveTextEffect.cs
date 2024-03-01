using TMPro;
using UnityEngine;

namespace Oneiromancer.TMP.Effects
{
    [System.Serializable]
    public class WaveTextEffect : BaseTextEffect
    {
        public override string Tag => "wave";
        
        [SerializeField] private float _sinSpacing;
        [SerializeField] private float _frequency;
        [SerializeField] private float _amplitude;
        
        protected override void ApplyToCharacter(TMP_Text text, TMP_CharacterInfo charInfo, int current, int end)
        {
            int materialIndex = charInfo.materialReferenceIndex;
            Vector3[] newVertices = text.textInfo.meshInfo[materialIndex].vertices;

            for (int vertexIdx = charInfo.vertexIndex; vertexIdx < charInfo.vertexIndex + 4; vertexIdx++)
            {
                Vector3 offset = new Vector2(
                    0,
                    _amplitude * Mathf.Sin(_frequency* (Time.realtimeSinceStartup + (current * _sinSpacing )))
                    );
                
                newVertices[vertexIdx] += offset;
            }
        }
    }
}