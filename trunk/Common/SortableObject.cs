using System;
using System.Data;
using System.ComponentModel;

namespace EveMarketMonitorApp.Common
{
	/// <summary>
	/// Summary description for SortableObject.
	/// </summary>
	public abstract class SortableObject : ICloneable, IEditableObject
	{
		public enum ObjectStateType{ Unchanged = 0, Added = 1, Changed = 2, Deleted = 3 };
        public SortableObject()
		{
		}

		public Type TypeOfObject 
		{
			get{return this.GetType();}
		}
		public void MarkForDeletion()
		{
			this.ObjectState = ObjectStateType.Deleted ;
		}
		public SortableCollection Parent =null;
		private bool _ispersistent = false;
		public bool IsPersistent
		{
			get{return _ispersistent ;}
			set{_ispersistent = value;}
		}
		private ObjectStateType _ObjectState  = ObjectStateType.Unchanged ;
		public ObjectStateType ObjectState 
		{
			get{return _ObjectState;}
			set{_ObjectState = value;}
		}
		private bool _IsDirty;
		public bool IsDirty
		{
			get
			{return _IsDirty;}
			set{_IsDirty = value;}
		}
		public int Compare(object obj1, object obj2)
		{
			try
			{
				int Rt = 0;
				if (obj1 ==null && obj2 ==null)
				{
					Rt = 0;
				}
				else if (obj1 ==null && obj2 != null)
				{
					Rt = -1;
				}
				else if (obj1!= null & obj2 == null)
				{
					Rt = 1;
				}
				else if (obj1 == obj2)
				{
					Rt = 0;
				}
				else
				{
					if (obj1.Equals(obj2))
					{
						Rt =0;
					}
					else 
					{
						Rt = 1;
					}
				}
				return Rt;
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}
		#region IEditableObject
		// Implements IEditableObject
		private bool inTxn = false;
		private bool IsNew = true;
		public void BeginEdit() 
		{
			if (!inTxn) 
			{
				inTxn = true;
				
			}
		}
		public void EndEdit() 
		{
			inTxn =false;
			IsNew = false;
		}
		public void CancelEdit() 
		{
			inTxn = false;
			if (IsNew)
			{
				IsNew = false;
				if (Parent != null)
				{
					this.Parent.Remove(this);
				}
			}
		}
		#endregion
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		public void SetDirtyFlag()
		{
			
			this.IsDirty = true;
			if (this.Parent !=null)
			{
				this.Parent.CollectionChanged(this);
			}
			if (this.IsPersistent )//l'object existe dans la base
			{
				this.ObjectState = ObjectStateType.Changed ;//objet changé
			}
			else
			{
				this.ObjectState = ObjectStateType.Added ;//objet ajouté
			}
			
		}
    }
}
