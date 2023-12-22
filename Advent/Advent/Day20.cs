using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent;

public class Day20
{
    public long Part1(string input)
    {
        var split = input.Split(Environment.NewLine);
        var modules = new Dictionary<string, IModule>();
        var connections = new List<(IModule, string[])>();

  //      modules["output"] = new Output("output");
        
        foreach (var l in split)
        {
            var split2 = l.Split(" -> ");
            IModule module;
            string name;
            if (split2[0] == "broadcaster")
            {
                name = split2[0];
                module = new Broadcaster(name);
            }
            else if(split2[0][0]== '%')
            {
                name = split2[0].Substring(1);
                module = new FlipFlop(name);
            }
            else if (split2[0][0] == '&')
            {
                name = split2[0].Substring(1);
                module = new Conjunction(name);
            }
            else
            {
                throw new Exception(split2[0]);
            }

            modules[name] = module;
            connections.Add((module,
                split2[1].Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));
        }

        foreach (var connection in connections)
        {
            foreach (var to in connection.Item2)
            {
                //connection.Item1.ConnectTo(modules[to]);
                
                if (!modules.ContainsKey(to))
                    modules[to] = new Output(to);
                connection.Item1.ConnectTo(modules[to]);
            }
        }

        var button = modules["broadcaster"];
        for (var i = 0; i < 1000; i++)
        {
            button.Pulse(false, button);
            while (IModule.Messages.Count > 0)
            {
                var message = IModule.Messages.Dequeue();
                message.to.Pulse(message.high, message.from);
            }
        }

        return IModule.TotalHigh * IModule.TotalLow;
    }

    public abstract class IModule
    {
        public static long TotalHigh;
        public static long TotalLow;
        public static Queue<(IModule from, bool high, IModule to)> Messages = new();

        public List<IModule> Connects = new();
        public List<IModule> Incoming = new();

        public string Name;

        public IModule(string name)
        {
            Name = name;
        }

        public abstract void Pulse(bool high, IModule from);

        public void ConnectTo(IModule to)
        {
            Connects.Add(to);
            to.ConnectFrom(this);
        }

        public virtual void ConnectFrom(IModule from)
        {
            
        }

        public abstract string Visual();
    }
    
    public class Output : IModule
    {
        public override void Pulse(bool high, IModule from)
        {
            if (high)
                TotalHigh++;
            else
                TotalLow++;
        }

        public Output(string name) : base(name)
        {
        }

        public override string Visual() => ".";
    }
    
    public class Broadcaster : IModule
    {
        public override void Pulse(bool high, IModule from)
        {
            if (high)
                TotalHigh++;
            else
                TotalLow++;
            
            foreach (var connect in Connects)
            {
                Messages.Enqueue((this, high, connect));
 //               Debug.WriteLine($"{Name} sends {(high ? "HIGH":"LOW")} -> {connect.Name}");
            }
            
        }
        
        public override string Visual() => "?";

        public Broadcaster(string name) : base(name)
        {
        }
    }
    
    public class Conjunction : IModule
    {
        public Dictionary<IModule, bool> States = new Dictionary<IModule, bool>();
        
        public override void Pulse(bool high, IModule from)
        {
            if (high)
                TotalHigh++;
            else
                TotalLow++;

            States[from] = high;
            var output = States.Values.All(s => s);
            foreach (var connect in Connects)
            {
                Messages.Enqueue((this, !output, connect));
  //              Debug.WriteLine($"{Name} sends {(!output ? "HIGH":"LOW")} -> {connect.Name}");
            }
        }

        public override string Visual() => "("+new string(States.Select(s => s.Value ? 'H' : 'L').ToArray())+")";
        
        public override void ConnectFrom(IModule from)
        {
            States[from] = false;
        }

        public Conjunction(string name) : base(name)
        {
        }
    }

    public class FlipFlop : IModule
    {
        public bool State;

        public override void Pulse(bool high, IModule from)
        {
            if (high)
                TotalHigh++;
            else
                TotalLow++;

            if (!high)
            {
                State = !State;
                foreach (var connect in Connects)
                {
                    Messages.Enqueue((this, State, connect));
//                    Debug.WriteLine($"{Name} sends {(State ? "HIGH":"LOW")} -> {connect.Name}");
                }
            }
        }

        public override string Visual() => State ? "+" : "-";

        public FlipFlop(string name) : base(name)
        {
        }
    }

    public long Part2(string input)
    {
        var split = input.Split(Environment.NewLine);
        var modules = new Dictionary<string, IModule>();
        var connections = new List<(IModule, string[])>();

        //      modules["output"] = new Output("output");
        
        foreach (var l in split)
        {
            var split2 = l.Split(" -> ");
            IModule module;
            string name;
            if (split2[0] == "broadcaster")
            {
                name = split2[0];
                module = new Broadcaster(name);
            }
            else if(split2[0][0]== '%')
            {
                name = split2[0].Substring(1);
                module = new FlipFlop(name);
            }
            else if (split2[0][0] == '&')
            {
                name = split2[0].Substring(1);
                module = new Conjunction(name);
            }
            else
            {
                throw new Exception(split2[0]);
            }

            modules[name] = module;
            connections.Add((module,
                split2[1].Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));
        }

        foreach (var connection in connections)
        {
            foreach (var to in connection.Item2)
            {
                //connection.Item1.ConnectTo(modules[to]);
                
                if (!modules.ContainsKey(to))
                    modules[to] = new Output(to);
                connection.Item1.ConnectTo(modules[to]);
            }
        }

        var button = modules["broadcaster"];
        for (var d = 0; d<5; d++)
        {
           Debug.WriteLine($"Loop {d}");
           // for (var i = 0; i < 1000; i++)
            {
             //   var a = string.Join(null, modules.Values.Select(m => m.Visual()));
             //   Debug.WriteLine(a);

             var seen = new HashSet<IModule>();
             var steps = 0;
                
                button.Pulse(false, button);
                while (IModule.Messages.Count > 0)
                {
                    steps++;
                    var message = IModule.Messages.Dequeue();
                    message.to.Pulse(message.high, message.from);
                    if(seen.Contains(message.to))
                        Debug.WriteLine($"Seen {message.to.Name} @ {steps}");
                    seen.Add(message.to);

                }
                
            }
        }

        return IModule.TotalHigh * IModule.TotalLow;
    }
    
    public long Part2a(string input)
    {
        var split = input.Split(Environment.NewLine);
        var modules = new Dictionary<string, IModule>();
        var connections = new List<(IModule, string[])>();

        //      modules["output"] = new Output("output");
        
        foreach (var l in split)
        {
            var split2 = l.Split(" -> ");
            IModule module;
            string name;
            if (split2[0] == "broadcaster")
            {
                name = split2[0];
                module = new Broadcaster(name);
            }
            else if(split2[0][0]== '%')
            {
                name = split2[0].Substring(1);
                module = new FlipFlop(name);
            }
            else if (split2[0][0] == '&')
            {
                name = split2[0].Substring(1);
                module = new Conjunction(name);
            }
            else
            {
                throw new Exception(split2[0]);
            }

            modules[name] = module;
            connections.Add((module,
                split2[1].Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));
        }

        foreach (var connection in connections)
        {
            foreach (var to in connection.Item2)
            {
                //connection.Item1.ConnectTo(modules[to]);
                
                if (!modules.ContainsKey(to))
                    modules[to] = new Output(to);
                connection.Item1.ConnectTo(modules[to]);
            }
        }

        var button = modules["broadcaster"];
        //for (var d = 0; true; d++)
        {
           // Debug.WriteLine($"Loop {d}");
            for (var i = 0; i < 1000; i++)
            {
                var a = string.Join(null, modules.Values.Select(m => m.Visual()));
                Debug.WriteLine(a);
                
                button.Pulse(false, button);
                while (IModule.Messages.Count > 0)
                {
                    var message = IModule.Messages.Dequeue();
                    if (message.to.Name == "rx")
                        if (!message.high)
                            return i + 1000L;//* d;
                    message.to.Pulse(message.high, message.from);
                }
                
            }
        }

        return IModule.TotalHigh * IModule.TotalLow;
    }
}