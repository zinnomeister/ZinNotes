using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZinNotes.Models
{
     class NotesModel
    {
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
		private bool _isDone;
        private string _note;

        public bool IsDone
		{
			get { return _isDone; }
			set { _isDone = value; }
		}

		public string Note
		{
			get { return _note; }
			set { _note = value; }
		}


	}
}
