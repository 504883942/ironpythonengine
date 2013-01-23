using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;

namespace ironpythonengine
{
    public abstract class IronPythonEngine
    {
        protected readonly ScriptEngine engine;
        protected readonly ScriptScope scope;

        public ScriptScope get_scope() { return this.scope; }
        public ScriptEngine get_engine() { return this.engine; }
    }

    public class SecureIronPythonEngine : IronPythonEngine
    {



    }

    public class UnrestrictedIronPythonEngine : IronPythonEngine
    {
    }

}
