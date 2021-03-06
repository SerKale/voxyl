﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class OpenLoad : MonoBehaviour 
	{
		public event Action<OpenLoad> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

                   // The name of the scene to load.               // This fades the scene out when a new scene is about to be loaded.
		public GameObject loadPanel;
		private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
		private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


		private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

		private void Awake() 
		{
			m_SelectionRadial = Camera.main.GetComponent<SelectionRadial>();
			m_InteractiveItem = GetComponent<VRInteractiveItem>();
		}

		private void OnEnable ()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
		}


		private void OnDisable ()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
		}


		private void HandleOver()
		{
			// When the user looks at the rendering of the scene, show the radial.
			m_SelectionRadial.Show();

			m_GazeOver = true;
		}


		private void HandleOut()
		{
			// When the user looks away from the rendering of the scene, hide the radial.
			m_SelectionRadial.Hide();

			m_GazeOver = false;
		}


		private void HandleSelectionComplete()
		{
			// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
			if (m_GazeOver)
				loadPanel.SetActive (true);
		}
			
	}