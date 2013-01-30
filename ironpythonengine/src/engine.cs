using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace ironpythonengine
{
    public abstract class IronPythonEngine
    {
        protected readonly ScriptEngine engine;
        protected readonly ScriptScope scope;

        protected abstract Tuple<ScriptEngine, ScriptScope> create_environment();
        public IronPythonEngine() {
            Tuple<ScriptEngine, ScriptScope> tup = this.create_environment();
            this.engine = tup.Item1;
            this.scope = tup.Item2;
        }

        public ScriptScope get_scope() { return this.scope; }
        public ScriptEngine get_engine() { return this.engine; }
    }

    /*public class SecureIronPythonEngine : IronPythonEngine
    {}*/

    public class UnrestrictedIronPythonEngine : IronPythonEngine
    {

        override protected Tuple<ScriptEngine, ScriptScope> create_environment(){
            ScriptEngine engine = Python.CreateEngine();
            return new Tuple<ScriptEngine, ScriptScope>(engine, engine.CreateScope());
        }
    }

}
