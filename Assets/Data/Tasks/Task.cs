using Ludio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Data.Tasks
{
    public abstract class Task : Activity
    {
        public virtual string Text { get; set; }
        public abstract bool IsDone { get; set; }

        public Task Parent { get; set; }
        public abstract Task Current { get; }

        public Task() { }
        public Task(string text = "", Task parentTask = null) { Parent = parentTask; Text = text; }

        public virtual bool NextTask() { return false; }

        public virtual PRACTICEMODE Mode
        {
            get { return PRACTICEMODE.PRACTICE; }
            set { throw new InvalidOperationException("Only training can change modes"); }
        }

        public virtual void Start() { IsDone = false; }
    }
}