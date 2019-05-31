using Ludio.Data.DB;
using Ludio.Overlay;
using Ludio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ludio.Data.Tasks
{
    public class Tutorial : Instruction, Iterable<Instruction>
    {
        public string Maker { get; set; }

        public Tutorial() {Init(); }
        public Tutorial(string name = "", Task parent = null) : base(name, parent) { Init(); }

        protected virtual void Init()
        {
            Children = new List<Instruction>();
        }
        public override void Start()
        {
            base.Start();
            _iterator = IteratorInstance();
            var i = IteratorInstance();
            for (i.First(); !i.IsDone(); i.Next())
            {
                i.Target.Start();
            }
        }

        public List<Instruction> Children { get; set; }
        public void Add(Instruction i) { Children.Add(i); }
        public void Remove(Instruction i) { Children.Remove(i); }

        public void Add(string text) { Add(new Instruction(text, this)); }

        private ListIterator<Instruction> _iterator;
        public override Iterator CreateIterator() { return IteratorInstance(); }
        public ListIterator<Instruction> IteratorInstance() { return new ListIterator<Instruction>(Children); }

        public override void Sync(DBVisitor db)
        {
            db.Sync(this);
            var i = IteratorInstance();
            for (i.First(); !i.IsDone(); i.Next())
            {
                i.Target.Sync(db);
            }
        }

        public override bool NextTask()
        {
            var done = _iterator.Target.NextTask();
            if (!done)
            {
                if (!_iterator.IsLast())
                {
                    _iterator.Next();
                    return true;
                }
            }
            return done;
        }

        public override Task Current
        {
            get
            {
                return _iterator.Target.Current;
            }
        }

        public override bool IsDone
        {
            get
            {
                return _iterator.Target.IsDone;
            }
            set
            {
                Children.ForEach(x => x.IsDone = value);
            }
        }

    }
}
