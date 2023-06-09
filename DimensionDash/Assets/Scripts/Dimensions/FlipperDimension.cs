using System.Collections.Generic;
using Movement;
using UnityEngine;

namespace Dimensions {
	[CreateAssetMenu(fileName = "Dimension", menuName = "Dimensions/FlipperDimension", order = 0)]
	public class FlipperDimension : DimensionDescription {

		[SerializeField] private PhysicsMaterial2D _newPhysicsMaterial;
		[SerializeField] private GameObject        _collisionBorderPrefab;
		
		private PhysicsMaterial2D _physicsMaterial;
		private GameObject        _collisionBorder;
		
		public override void Apply(List<GameObject> players) {
			foreach (var p in players) {
				if (p && p.TryGetComponent(out BewegenFlipper b)) {
					b.enabled = true;
					b.EnableMode();
				}
				if (p && p.TryGetComponent(out CircleCollider2D cc)) {
					_physicsMaterial  = cc.sharedMaterial;
					cc.sharedMaterial = _newPhysicsMaterial;
				}
			}

			if (!_collisionBorder)
				_collisionBorder = Instantiate(_collisionBorderPrefab);
		}

		public override void UnApply(List<GameObject> players) {
			foreach (var p in players) {
				if (p && p.TryGetComponent(out BewegenFlipper b)) {
					b.DisableMode();
					b.enabled = false;
				}
				if (p && p.TryGetComponent(out CircleCollider2D cc)) {
					cc.sharedMaterial = _physicsMaterial;
				}
			}
			
			if (_collisionBorder)
				Destroy(_collisionBorder);
			
			_collisionBorder = null;
		}
	}
}
