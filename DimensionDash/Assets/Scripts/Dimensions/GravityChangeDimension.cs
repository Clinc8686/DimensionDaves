using System.Collections.Generic;
using UnityEngine;

namespace Dimensions {
	[CreateAssetMenu(fileName = "Dimension", menuName = "Dimensions/GravityChange", order = 0)]
	public class GravityChangeDimension : DimensionDescription {

		[SerializeField] private Vector2 _newGravity;

		private Vector2 _previousGravity;
		
		public override void Apply(List<GameObject> players) {
			_previousGravity  = Physics2D.gravity;
			Physics2D.gravity = _newGravity;
		}

		public override void UnApply(List<GameObject> players) {
			Physics2D.gravity = _previousGravity;
		}
	}
}
