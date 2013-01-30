using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ironpythonengine;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace Whatever {
    class Program {
        static void Main(string[] args) {

            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope   = engine.CreateScope();

            scope.SetVariable("x", 0);
            engine.Execute("x=4", scope);
            Console.Write(scope.GetVariable("x"));

            int x = engine.Execute<int>("x-1", scope);
            Console.Write(x);


        }
    }
}
