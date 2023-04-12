using System.Collections.Generic;
using UnityEngine;

namespace emilyFS {
	public class File {
		public string Name;
		public Sprite Icon;

		public File(string name, Sprite icon) {
			Name = name;
			Icon = icon;
		}

		public File() {}

		public virtual GameObject Open() {
			// default case, logs file name to console
			Debug.Log("File \"" + Name + "\" does not have an implementation.");
			// TODO this probably isn't the best idea
			return new GameObject();
		}
	}

	public class Folder : File {
		public Folder Parent;
		public List<File> Contents;

		public Folder(string name, Sprite icon, Folder parent, List<File> contents) {
			Name = name;
			Icon = icon;
			Parent = parent;
			Contents = contents;
		}

		// If no sprite specified, use default empty folder icon
		public Folder(string name, Folder parent, List<File> contents) {
			Name = name;
			Icon = Resources.Load<Sprite>("Sprites/EmptyFolder");
			Parent = parent;
			Contents = contents;
		}
		
		public Folder() {}
		
		public override GameObject Open() {
			return FileOpener.LoadFolder(this);
		}
	}

	public class ZIPFolder : Folder {
		private readonly string _password;
		public ZIPFolder(string name, Folder parent, List<File> contents, string password) {
			Name = name;
			Icon = Resources.Load<Sprite>("Sprites/FolderZip");
			Parent = parent;
			Contents = contents;
			_password = password;
		}

		public override GameObject Open() {
			// Instantiate a password window
			GameObject authWindow = Resources.Load<GameObject>("Prefabs/Window Types/Password Zip");
			// Give the checker component the necessary target & password
			authWindow.GetComponent<PasswordCheck>().target = this;
			authWindow.GetComponent<PasswordCheck>().password = _password;
			return authWindow;
		}
	}

	public class Shortcut : File {
		public Folder Target;

		public Shortcut(string name, Sprite icon, Folder target) {
			Name = name;
			Icon = icon;
			Target = target;
		}

		public override GameObject Open() {
			return FileOpener.LoadFolder(Target);
		}
	}
}