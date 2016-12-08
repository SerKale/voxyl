using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using System.Collections.Generic;

public class MediaPanel : MonoBehaviour {

	public Transform mediaThumbnailTemplate;
	public Transform m_ImageSpawner;
	
	public VRInput m_VrInput;

	private int index = 0;

	/* private string[,] files = new string[,] {
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"Chandra", "chandra"},
            {"Airplane", "airplane"},
            {"Blue Clouds", "blue-clouds-day-fluffy-53594" },
            {"Alleyway", "alleyway" },
            {"Bridge", "bridge-path-straight-wooden" }
		};*/

	private string[,] files = new string[,] {
			{"2015-04-umbrella-guy-rain", "2015-04-umbrella-guy-rain"},
			{"355699-valley", "355699-valley"},
			{"Creepycemetery", "Creepycemetery"},
			{"Sailboat-sunset", "Sailboat-sunset"},
			{"SkyScraper", "SkyScraper"},
			{"Snow-Covered Sierra Nevada Mountains, California", "Snow-Covered Sierra Nevada Mountains, California"},
			{"Snow", "Snow"},
			{"Super-House-Interior", "Super-House-Interior"},
			{"airplane", "airplane"},
			{"alleyway", "alleyway"},
			{"beach-01", "beach-01"},
			{"blackmana", "blackmana"},
			{"blue-clouds-day-fluffy-53594", "blue-clouds-day-fluffy-53594"},
			{"bluemana", "bluemana"},
			{"bow-and-arrow", "bow-and-arrow"},
			{"bridge-path-straight-wooden", "bridge-path-straight-wooden"},
			{"bunnies", "bunnies"},
			{"car", "car"},
			{"cat", "cat"},
			{"chandra", "chandra"},
			{"choosing-roses-garden-08312015", "choosing-roses-garden-08312015"},
			{"cliff", "cliff"},
			{"computer", "computer"},
			{"dog", "dog"},
			{"dusk", "dusk"},
			{"earth-from-space", "earth-from-space"},
			{"fire", "fire"},
			{"flower-197343_1920", "flower-197343_1920"},
			{"flute-and-sheet-music", "flute-and-sheet-music"},
			{"girl-balloons-silhouette", "girl-balloons-silhouette"},
			{"greenmana", "greenmana"},
			{"guitar-in-flowers", "guitar-in-flowers"},
			{"guitar", "guitar"},
			{"half-dome-shot_h", "half-dome-shot_h"},
			{"horseback-riding", "horseback-riding"},
			{"iPhone-couple-silhouette-1024x1024", "iPhone-couple-silhouette-1024x1024"},
			{"kitten-little", "kitten-little"},
			{"kwansan-cherry-tree-bench", "kwansan-cherry-tree-bench"},
			{"lightningbolts", "lightningbolts"},
			{"lion", "lion"},
			{"llama", "llama"},
			{"moon", "moon"},
			{"nature-forest-industry-rails", "nature-forest-industry-rails"},
			{"o-STAINED-GLASS-WINDOW-900", "o-STAINED-GLASS-WINDOW-900"},
			{"poison-garden", "poison-garden"},
			{"rain-04", "rain-04"},
			{"redmana", "redmana"},
			{"river", "river"},
			{"road-photography-2", "road-photography-2"},
			{"sea-gull-bird-sky-nature", "sea-gull-bird-sky-nature"},
			{"ship", "ship"},
			{"silhouette-woman-sunset-profile", "silhouette-woman-sunset-profile"},
			{"silhouette", "silhouette"},
			{"skogafoss_waterfall_iceland", "skogafoss_waterfall_iceland"},
			{"space-04", "space-04"},
			{"stars", "stars"},
			{"subway", "subway"},
			{"swingset", "swingset"},
			{"sword", "sword"},
			{"temple", "temple"},
			{"thicket", "thicket"},
			{"tiger", "tiger"},
			{"tree-01", "tree-01"},
			{"underwater", "underwater"},
			{"volcano-05", "volcano-05"},
			{"whitemana", "whitemana"}
	};

	private const int IMAGES_PER_PAGE = 9;
	private int maxIndex;
	
	private void OnEnable() {
		m_VrInput.OnSwipe += HandleSwipe;
	}

	private void OnDisable() {
		m_VrInput.OnSwipe -= HandleSwipe;
	}
	
	// Use this for initialization
	void Start () {
		maxIndex = files.GetLength(0) / IMAGES_PER_PAGE;

		RenderImagesForIndex(index);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateImage(string url) {
		// consider doing this with first class functions
		// This function, I think, is what would get passed in
		m_ImageSpawner.GetComponent<AddPhotoButton>().CreateImage(url);

		// eventually move this out?
		gameObject.SetActive(false);
	}

	private void HandleSwipe(VRInput.SwipeDirection dir) {
		if(gameObject.activeSelf) {
			switch(dir) {
				case VRInput.SwipeDirection.UP:	
					if(index > 0) { RenderImagesForIndex(--index); }
					break;
				
				case VRInput.SwipeDirection.DOWN:	
					if(index < maxIndex) { RenderImagesForIndex(++index); }
					break;
			}
		}
	}

	private void RenderImagesForIndex(int index) {		
		int numfiles = files.GetLength(0);
		
		// clear images
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		// render images
		int start = index * IMAGES_PER_PAGE;
		int num = start + IMAGES_PER_PAGE > numfiles ? numfiles - start : IMAGES_PER_PAGE;
		for(int i = 0; i < num; i++) {
			Transform obj = (Transform) Instantiate(mediaThumbnailTemplate);
			Vector3 originalScale = obj.transform.localScale;	
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-3f + 3f * (i/3), .2f, -3.5f + 3f * (i%3));
			obj.transform.rotation = new Quaternion(0,0,0,0);
			obj.transform.Rotate(0, 90, 0);
			obj.transform.localScale = originalScale;
			obj.GetComponent<MediaThumbnail>().SetTexture(files[start + i, 1]);
		}
	}
}
