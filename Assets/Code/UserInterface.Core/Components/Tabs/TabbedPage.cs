using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainMenu.UI
{
	public class TabbedPage : MonoBehaviour
	{
		[SerializeField] private int defaultOption = 0;
		
		private List<Tab> _tabs;
		private List<Page> _pages;
		private bool _initialized = false;

		private void Awake()
		{
			_tabs = GetComponentsInChildren<Tab>().ToList();
			_pages = GetComponentsInChildren<Page>().ToList();

			foreach (var tab in _tabs)
			{
				tab.OnClicked += TabClicked;
			}
		}

		private void Start()
		{
			SelectIndex(defaultOption);

			_initialized = true;
		}

		public void SelectIndex(int index)
		{
			for (int i = 0; i < _tabs.Count; i++)
			{
				_tabs[i].SetSelected(i == index);
				_pages[i].SetSelected(i == index);
			}
		}

		private void OnEnable()
		{
			if (_initialized)
			{
				SelectIndex(defaultOption);
			}
		}

		private void TabClicked(Tab tab)
		{
			int indexOfTab = _tabs.IndexOf(tab);
			
			SelectIndex(indexOfTab);
		}

		private void OnCanvasHierarchyChanged()
		{
			foreach (var tab in _tabs)
			{
				tab.OnClicked -= TabClicked;
			}
			
			Awake();
		}
	}
}