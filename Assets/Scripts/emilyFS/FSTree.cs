using System.Collections.Generic;
using UnityEngine;

namespace emilyFS {
	public class FSTree {
		// Root Folder
		public static Folder FS_root = new Folder("C:", Resources.Load<Sprite>("Sprites/MyComputer"), FS_root, new List<File>() {
			System,
			My_Documents,
			Desktop,
			Games
		});
		
		// System folder
		private static Folder System = new Folder("System", FS_root, new List<File>() { });
		
		// My Documents
		private static Folder My_Documents = new Folder("My Documents", FS_root, new List<File>() {
			Desktop
		});
		
		// Desktop
		private static Folder Desktop = new Folder("Desktop", FS_root, new List<File>() {
			My_Computer,
			Trashcan,
			My_Documents,
			// TODO GoSurf
			// TODO BassIM
			New_Folder,
			New_Folder_1,
			Photos_ZIP
		});
		// My Computer shortcut
		private static Shortcut My_Computer = new Shortcut("My Computer", Resources.Load<Sprite>("Sprites/MyComputer"), FS_root);
		// Trashcan
		private static Folder Trashcan = new Folder("Trashcan", Resources.Load<Sprite>("Sprites/Trashv2_Full"), Desktop, new List<File>());
		// My Documents can be referenced as is
		// GoSurf
		// BassIM
		// New Folder
		private static Folder New_Folder = new Folder("New Folder", Desktop, new List<File>());
		// New Folder (1)
		private static Folder New_Folder_1 = new Folder("New Folder (1)", Desktop, new List<File>());
		// photos.zip
		// TODO better password
		private static ZIPFolder Photos_ZIP = new ZIPFolder("photos.zip", Desktop, new List<File>(), "TEST");
		
		// Games folder
		private static Folder Games = new Folder("Games", FS_root, new List<File>());
	}
}