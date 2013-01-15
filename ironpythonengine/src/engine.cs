using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;

namespace ironpythonengine
{
    public abstract class IronPythonEngine
    {
        private readonly ScriptEngine engine;

        public ScriptScope get_scope() {return null;}
        public ScriptEngine get_engine(){return null;}
    }

    public class SecureIronPythonEngine : IronPythonEngine
    {
    }

    public class UnrestrictedIronPythonEngine : IronPythonEngine
    {
    }

}
