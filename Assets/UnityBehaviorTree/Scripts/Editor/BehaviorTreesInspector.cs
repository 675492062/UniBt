﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UniBt.Editor
{
	[CustomEditor(typeof(BehaviorTrees))]
	public class BehaviorTreesInspector : NodeInspector
	{
		public override void OnEnable()
		{
			base.OnEnable();
			EditorApplication.projectWindowItemOnGUI += OnDoubleClick;
		}
		
		public override void OnDisable()
		{
			base.OnDisable();
			EditorApplication.projectWindowItemOnGUI -= OnDoubleClick;
		}
		
		public override void OnInspectorGUI()
		{
			if (node.parent != null)
			{
				base.OnInspectorGUI();
			}
		}
		
		public virtual void OnDoubleClick(string guid, Rect rect)
		{
			if (Event.current.type == EventType.MouseDown &&
				Event.current.clickCount == 2 &&
				rect.Contains(Event.current.mousePosition))
			{
				BehaviorEditor.ShowEditorWindow();
				BehaviorEditor.SelectBehaviorTrees(target as BehaviorTrees);
			}
		}
	}
}
