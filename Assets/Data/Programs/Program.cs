using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ludio.Data.DB;
using Ludio.Data.Tasks;
using Ludio.Util;
using UnityEngine;

namespace Ludio.Data
{
    public class Program : Task, Iterable<Tutorial>
    {
        public static string prevOpenProgram = "";
        public static string OpenProgram = "";

        public string Name { get; set; }
        public string Color { get; set; }
        public Training Open { get; set; }

        public Program() { Init(); }
        
        public Program(string name, string color)
        {
            Name = name;
            Color = color;
            Init();
        }

        public List<Tutorial> Children { get; set; }

        public override bool IsDone
        {
            get { return Children.Last().IsDone; }
            set { }
        }

        public override Task Current { get { return this; } }

        private void Init()
        {
            Children = new List<Tutorial>();
        }

        public void Add(Tutorial o) { Children.Add(o); }
        public void Remove(Tutorial o) { Children.Add(o); }
        public ListIterator<Tutorial> IteratorInstance() { return new ListIterator<Tutorial>(Children); }

        public override void Sync(DBVisitor db) { db.Sync(this); }

        public override Iterator CreateIterator() { return IteratorInstance(); }

        public bool IsProgramOpen()
        {
            var newProgram = OverlayFactory.HANDLER().ActiveWindow.GetTitle().ToLower();
            if(!newProgram.Contains(Application.productName.ToLower()))
            {
                prevOpenProgram = OpenProgram;
                OpenProgram = newProgram;
                return OpenProgram.Contains(Name.ToLower());
            }
            return prevOpenProgram.Contains(Name.ToLower());
        }
    }
}
