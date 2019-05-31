using System.Collections.Generic;
using Ludio.Data.Tasks;
using System.Linq;
using Ludio.Commands;

namespace Ludio.Data
{
    public class DATA : ISender<Program>
    {
        private static DATA _global;
        public static DATA GLOBAL
        {
            get
            {
                if (_global == null) _global = new DATA();
                return _global;
            }
        }

        public List<IListener<Program>> Children { get; private set; }

        public void Add(IListener<Program> o) { Children.Add(o); }
        public void Remove(IListener<Program> o) { Children.Remove(o); }

        private List<Program> Programs = new List<Program>();

        public Task Task { get; set; }
        public Program Program { get; private set; }

        private DATA() { Load(); }

        public void SetProgram(string name)
        {
            if (name == null || name == string.Empty) Program = null;
            else Program = Programs.Find(x => x.Name == name);

            Children.ForEach(x => x.Updated(Program));
        }

        public void SetTask(string name)
        {
            if (name == null || name == string.Empty) Task = null;
            else Task = Program.Children.Find(x => ((Tutorial)x).Text == name);

            Children.ForEach(x => x.Updated(Program));
        }

        private void Load()
        {
            Children = new List<IListener<Program>>();
            Programs = LocalLoader.INSTANCE.LoadPrograms();
            Program = Programs.ElementAt(0);
            Task = Program.Children.ElementAt(0);
        }
    }
}
