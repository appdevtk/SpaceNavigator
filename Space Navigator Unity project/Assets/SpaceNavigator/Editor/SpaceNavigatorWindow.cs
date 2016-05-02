#if UNITY_EDITOR
using System;
using UnityEditor;

namespace SpaceNavigatorDriver {

	[Serializable]
	public class SpaceNavigatorWindow : EditorWindow, IDisposable {

		/// <summary>
		/// Initializes the window.
		/// </summary>
		[MenuItem("Window/SpaceNavigator/Settings Window &s")]
		public static void Init() {
			SpaceNavigatorWindow window = GetWindow(typeof(SpaceNavigatorWindow)) as SpaceNavigatorWindow;

			if (window) {
				window.Show();
			}
		}

        [MenuItem("Window/SpaceNavigator/Mode/Fly #%L")]
        public static void SwitchModeToFly()
        {
            Settings.Mode = OperationMode.Fly;
            DisplayChanges();
        }

        [MenuItem("Window/SpaceNavigator/Mode/Orbit #%O")]
        public static void SwitchModeToOrbit()
        {
            Settings.Mode = OperationMode.Orbit;
            DisplayChanges();
        }

        [MenuItem("Window/SpaceNavigator/Mode/Telekinesis #%T")]
        public static void SwitchToTelekinesis()
        {
            Settings.Mode = OperationMode.Telekinesis;
            DisplayChanges();
        }

        [MenuItem("Window/SpaceNavigator/Mode/Grab Move #%G")]
        public static void SwitchModeToGrabMove()
        {
            Settings.Mode = OperationMode.GrabMove;
            DisplayChanges();
        }

        [MenuItem("Window/SpaceNavigator/Camera/Orthographic+Perspective #%F1")]
        public static void SwitchCamOrthographic()
        {
            Settings.CamOrthographic = CameraOrthographic.Switch;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Top #%F2")]
        public static void SwitchCamPresetToTop()
        {
            Settings.CamPreset = CameraPreset.Top;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Bottom #%F3")]
        public static void SwitchCamPresetToBottom()
        {
            Settings.CamPreset = CameraPreset.Bottom;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Front #%F4")]
        public static void SwitchCamPresetToFront()
        {
            Settings.CamPreset = CameraPreset.Front;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Back #%F5")]
        public static void SwitchCamPresetToBack()
        {
            Settings.CamPreset = CameraPreset.Back;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Left #%F6")]
        public static void SwitchCamPresetToLeft()
        {
            Settings.CamPreset = CameraPreset.Left;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Right #%F7")]
        public static void SwitchCamPresetToRight()
        {
            Settings.CamPreset = CameraPreset.Right;
        }

        [MenuItem("Window/SpaceNavigator/Camera/Iso #%F8")]
        public static void SwitchCamPresetToIso()
        {
            Settings.CamPreset = CameraPreset.Iso;
        }

        public static void OnDisable() {
			// Write settings to PlayerPrefs when EditorWindow is closed.
			Settings.Write();
		}

		public static void OnDestroy() {
			// Write settings to PlayerPrefs when EditorWindow is closed.
			Settings.Write();
		}

		// This does not get called, unfortunately...
		public void OnApplicationQuit() {
			ViewportController.OnApplicationQuit();
		}

		public void OnSelectionChange() {
			ViewportController.StoreSelectionTransforms();
		}

		public void OnGUI() {
			Settings.OnGUI();
		}

		public void Dispose() {
			// Write settings to PlayerPrefs when EditorWindow is closed.
			Settings.Write();
		}

        private static void DisplayChanges()
        {
            SpaceNavigatorWindow window = GetWindow(typeof(SpaceNavigatorWindow)) as SpaceNavigatorWindow;
            if (window)
            {
                window.Repaint();
            }
        }
	}
}
#endif