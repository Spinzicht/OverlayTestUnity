using System.Collections.Generic;
using Ludio.Data.DB;
using Ludio.Util;

namespace Ludio.Data.Tasks
{
    public enum PRACTICEMODE
    {
        PRACTICE,
        CHALLENGE
    }

    public class Training : Tutorial
    {
        public Training() : base() { }
        public Training(Task parent, string text = "") : base(text, parent) { }

        public override PRACTICEMODE Mode { get; set; }

        protected override void Init()
        {
            base.Init();
            Mode = PRACTICEMODE.CHALLENGE;
        }

        public override bool NextTask()
        {
            if (Mode == PRACTICEMODE.CHALLENGE)
                return false;

            return base.NextTask();
        }

        public override Task Current
        {
            get
            {
                if (Mode == PRACTICEMODE.CHALLENGE)
                    return this;
                else return base.Current;
            }
        }

        private bool _isDone;
        public override bool IsDone
        {
            get
            {
                if (Mode == PRACTICEMODE.CHALLENGE)
                    return _isDone;
                else return base.IsDone;
            }
            set
            {
                if (Mode == PRACTICEMODE.CHALLENGE)
                    _isDone = value;
                else base.IsDone = value;
            }
        }

        public override void Start()
        {
            base.Start();
            _isDone = false;
            base.IsDone = false;
            Mode = PRACTICEMODE.CHALLENGE;
        }
    }
}
